using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Student_Space_1.Models;
using Student_Space_1.Views;


namespace Student_Space.ViewModels
{
    public class ToDoViewModel : INotifyPropertyChanged
    {

        //Implement Property Change
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Declare Commands
        public ICommand AddTask { get; }
        public ICommand DeleteTask { get; }


        //Class Constructor
        public ToDoViewModel()
        {

            AddTask = new Command(AddItem);
            DeleteTask = new Command(DeleteItem);

            //Access Shared Observable Collection
            TaskListDB = TaskDB.Instance;
        }

        async void AddItem()
        {
            //Assign Default Task Item Properties
            DateTime duedate = DateTime.Today;
            string priority = "#00BCD4";
            string notes = null;
            string reminders = null;
            TimeSpan duetime = new TimeSpan(4, 15, 26);

            string result = "";

            //Open Alert Message to Ask for What Task
            result = await App.Current.MainPage.DisplayPromptAsync("Add Task", "What did you want to do?", "Add", "Cancel", "Write Something...");

            if (String.IsNullOrWhiteSpace(result))
            {
                await App.Current.MainPage.DisplayAlert("Error!", "Oh No! You tried to add an empty Task.", "Ok");
            }
            else
            {
                //Create a New Task
                Task_Item new_task = new Task_Item
                {
                    TaskName = result,
                    DueDate = duedate,
                    DueTime = duetime,
                    Priority = priority,
                    Notes = notes,
                    Reminders = reminders,
                };

                //Add Task to List of Tasks 
                ToDoTasks.Add(new_task);
            } 
        }

        void DeleteItem(object item)
        {
            //Remove Item from To Do List
            var task = item as Task_Item;
            ToDoTasks.Remove(task);
        }

        public string TaskSetting { get; set; }

        async void OpenSettings()
        {

            //Reference: https://devblogs.microsoft.com/xamarin/xamarin-forms-shell-query-parameters/

            try
            {

                await Shell.Current.GoToAsync($"{nameof(ToDoSettings)}?TaskSetting={TaskSetting}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        //public Task_Item SelectedItem { get; set; }

        private Task_Item _selectedTask { get; set; }
        public Task_Item Selected
        {
            get { return _selectedTask; }
            set
            {
                try
                {
                    if (value != null)
                    {
                        _selectedTask = value;

                        TaskSetting = _selectedTask.TaskName;
                        
                        OnPropertyChanged(nameof(Selected));

                        //Go to the Settings Page
                        OpenSettings();
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        //Handle Data
        private TaskDB TaskListDB;

        private ObservableCollection<Task_Item> myVar;
        public ObservableCollection<Task_Item> ToDoTasks //Bind this to the View
        {
            get { return TaskListDB.Mylist; }
            set
            {
                myVar = value;
                OnPropertyChanged();
            }

        }
    }
}
