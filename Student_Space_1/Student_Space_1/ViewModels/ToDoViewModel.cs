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
    public class ToDoViewModel : BindableObject
    {
        int ID_Num = 0;
        public ICommand AddTask { get; }
        public ICommand DeleteTask { get; }

        public ICommand GoSetting { get; }
        public Task_Item SelectedItem { get; set; }

        public ObservableCollection<Task_Item> _Tasks = new ObservableCollection<Task_Item>(); //Initialize List

        public ToDoViewModel()
        {

            Setup();
            AddTask = new Command(AddItem);
            DeleteTask = new Command(DeleteItem);
            //GoSetting = new Command(OpenSettings);

        }

        public ObservableCollection<Task_Item> Tasks
        {
            set
            {
                _Tasks = value;
                OnPropertyChanged();
            }

            get { return _Tasks; }
        }

        async void AddItem()
        {
            string duedate = null;
            int ID = ID_Num + 1;
            string priority = null;
            string notes = null;
            string reminders = null;

            //Open Alert Message to Ask for What Task
            string result = await App.Current.MainPage.DisplayPromptAsync("Add Task", "What did you want to do?", "Add", "Cancel");

            //Create a New Task
            Task_Item new_task = new Task_Item
            {
                TaskName = result,
                DueDate = duedate,
                ID = ID_Num,
                Priority = priority,
                Notes = notes,
                Reminders = reminders,
            };

            //Add Task to List of Tasks 
            Tasks.Add(new_task);

            Console.WriteLine("Answer: " + result + "-------" + new_task.ToString());
        }

        void DeleteItem(object item)
        {
            //Remove Item from To Do List
            //Application.Current.MainPage.DisplayAlert("Alert", SelectedItem + " Item Should be Deleted", "Ok"); Testing Purposes

            var task = item as Task_Item;
            Tasks.Remove(task);
        }

/*        async void OpenSettings()
        {
            var settingspage = new ToDoListSetting(Tasks);
            settingspage.BindingContext = SelectedItem;
            await Application.Current.MainPage.Navigation.PushModalAsync(settingspage);

        }*/

        //Fake Data for Easier Testing
        void Setup()
        {
            Tasks = new ObservableCollection<Task_Item>
            {
                new Task_Item
                {
                    TaskName = "Watch Lecture 100",
                    DueDate = null,
                    ID = 1,
                    Priority = null,
                    Notes = null,
                    Reminders = null,
                },

                 new Task_Item
                {
                    TaskName = "Watch Lecture 2000",
                    DueDate = null,
                    ID = 2,
                    Priority = null,
                    Notes = null,
                    Reminders = null,
                },

                 new Task_Item
                {
                    TaskName = "Watch Lecture 12312312",
                    DueDate = null,
                    ID = 3,
                    Priority = null,
                    Notes = null,
                    Reminders = null,
                },

            };
        }

    }
}
