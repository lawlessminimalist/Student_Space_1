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
using System.Security.Cryptography.X509Certificates;

namespace Student_Space.ViewModels
{
    public class CalendarViewModel : BaseViewModel, INotifyPropertyChanged
    {

        //Implement Property Change
        public new event PropertyChangedEventHandler PropertyChanged;
        protected new void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
        public string currentday;
        public string CurrentDay
        {
            get { return currentday; }
            set
            {
                currentday = value;
                OnPropertyChanged();
            }
        }

        CalendarMonth calendar;

        //Declare Commands
        public ICommand GoToCurrentWeek { get; }
        public ICommand DeleteTask { get;}
        public ICommand AddTask { get; }
        public ICommand PreviousCalendarCommand { get; }
        public ICommand NextCalendarCommand { get; }

        public

        public string month;
        public string CurrentMonth
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged();
            }
        }

        public CalendarViewModel(CalendarMonth calendar)
        {

            SetupData();

            this.calendar = calendar;
            GoToCurrentWeek = new Command(OpenCalendarWeek);
            AddTask = new Command(AddItem);
            DeleteTask = new Command(DeleteItem);

            TaskListDB = TaskDB.Instance;
        }

        async void AddItem()
        {
            //Assign Default Task Item Properties
            DateTime duedate = DateTime.Today;
            TimeSpan duetime = new TimeSpan(4, 15, 26);
            string priority = "#00BCD4";
            string notes = null;
            string reminders = null;

            //Get Task via User Input on Display Prompt
            string result = "";
            result = await App.Current.MainPage.DisplayPromptAsync("Add Task", "What did you want to do?", "Add", "Cancel", "Write Something...");

            if (String.IsNullOrWhiteSpace(result))
            {
                await App.Current.MainPage.DisplayAlert("Error!", "Oh No! You tried to add an empty Task.", "Ok");
            }
            else
            {

                try
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
                    Calendartask.Add(new_task);

                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "something has gone wrong..." + ex, "Ok");
                }

            }
        }
        //Remove Task from List by removing object
        void DeleteItem(object item)
        {
            //Remove Item from Collection
            var task = item as Task_Item;
            Calendartask.Remove(task);
        }

        public string TaskSetting { get; set; } //Variable that is passed to next page

        //Open a Settings Page for the selected Task
        async void OpenSettings()
        {
            //Code Reference: https://devblogs.microsoft.com/xamarin/xamarin-forms-shell-query-parameters/

            try
            {
                //Go to Next Page and Pass Selected Task as Data
                await Shell.Current.GoToAsync($"{nameof(ToDoSettings)}?TaskSetting={TaskSetting}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        //public Task_Item SelectedItem { get; set; }

        private Task_Item _selectedTask { get; set; }
        public Task_Item Selected_Item
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
                        _selectedTask = null;
                        OnPropertyChanged(nameof(Selected_Item));


                        //Go to the Settings Page
                        OpenSettings();


                        Console.WriteLine("This Line should be Null no colour la");
                    }

                }
                catch (Exception ex)
                {
                    App.Current.MainPage.DisplayAlert("Error!", "Something went wrong!" + ex, "Ok");

                }
            }
        }

        async void OpenCalendarWeek()
        {
            await Shell.Current.GoToAsync(nameof(CalendarWeek));
        }


        void SetupData()
        {
            DateTime today = DateTime.Today;
            CurrentDay = today.ToString("f");
            CurrentMonth = today.ToString("MMM");
        }


        //Handle Data
        private TaskDB TaskListDB;

        private ObservableCollection<Task_Item> myVar;
        public ObservableCollection<Task_Item> Calendartask //Bind this to the View
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