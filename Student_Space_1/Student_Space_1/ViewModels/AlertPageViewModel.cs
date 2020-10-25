using Student_Space_1.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Student_Space_1.Views;


namespace Student_Space.ViewModels
{
    public class AlertPageViewModel : BindableObject
    {

        public ICommand AddTask { get; }
        public ICommand NavigateCalendar { get; }
        public ICommand Test { get; }




        public AlertPageViewModel()
        {

            //Commands
            AddTask = new Command(AddItem);
            NavigateCalendar = new Command(OpenCalendar);
            //Access Shared Observable Collection (List of Tasks)
            TaskListDB = TaskDB.Instance;


            try {
                GenerateToday();
                GenerateMonth();
                GenerateAlerts();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }

        void test() {
            App.Current.MainPage.DisplayAlert("Error!", "No one something went wrong!", "Ok");
        }

        public void GenerateAlerts()
        {
            for (int x = 0 ; x < _tasks.Count; x--)
            {
                if (_tasks[x].DueTime.Hours == DateTime.Now.Hour)
                {
                    Task_Item e = _tasks[x];
                    _todayList.Add(e);
                }

            }
        }

        public void GenerateToday()
        {
            for (int x = _tasks.Count - 1; x >= 0; x--) 
            {
                if (_tasks[x].DueDate.Date == DateTime.Now.Date) 
                {
                    Task_Item e = _tasks[x];
                    _todayList.Add(e);
                }

            }
        }

        public void GenerateMonth()
        {
            for (int x = 0; x < _tasks.Count; x++)
            {
                if (_tasks[x].DueDate.Month == DateTime.Now.Month)
                {
                    Task_Item e = _tasks[x];
                    MonthList.Add(e);
                }

            }
        }


        public async void OpenCalendar()
        {
            //Code Reference: https://devblogs.microsoft.com/xamarin/xamarin-forms-shell-query-parameters/

            try
            {
                //Go to Next Page and Pass Selected Task as Data
                await Shell.Current.GoToAsync($"{nameof(CalendarMonth)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }



        public string TaskSetting { get; set; } //Variable that is passed to next page

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


                    }

                }
                catch (Exception ex)
                {
                    App.Current.MainPage.DisplayAlert("Error!", "No one something went wrong!" + ex, "Ok");

                }
            }
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
                //Create a New Task
                Task_Item new_task = new Task_Item
                {
                    TaskName = result,
                    DueTime = duetime,
                    Priority = priority,
                    Notes = notes,
                    Reminders = reminders,
                };

                //Add Task to List of Tasks 
                _tasks.Add(new_task);
                GenerateMonth();
                GenerateToday();
                GenerateAlerts();
            }
        }



            //Handle Data
        private TaskDB TaskListDB;

        private ObservableCollection<Task_Item> TodayList = new ObservableCollection<Task_Item>();
        private ObservableCollection<Task_Item> MonthList = new ObservableCollection<Task_Item>();
        private ObservableCollection<Task_Item> AlertList = new ObservableCollection<Task_Item>();



        private ObservableCollection<Task_Item> myVar;
        public ObservableCollection<Task_Item> _tasks //Bind this to the View
        {
            get { return TaskListDB.Mylist; }
            set
            {
                myVar = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Task_Item> _alertList
        {
            get => MonthList; set { MonthList = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Task_Item> _monthList
        {
            get => MonthList; set { MonthList = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Task_Item> _todayList { get => TodayList; set { TodayList = value; OnPropertyChanged();}
        }
    }
}

    
