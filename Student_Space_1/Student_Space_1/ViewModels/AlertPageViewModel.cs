using Student_Space_1.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace Student_Space.ViewModels
{
    public class AlertPageViewModel : BindableObject
    {

        public ICommand AddTask { get; }




        public AlertPageViewModel()
        {

            //Commands
            AddTask = new Command(AddItem);

            //Access Shared Observable Collection (List of Tasks)
            TaskListDB = TaskDB.Instance;

            GenerateToday();


        }


        public void GenerateToday()
        {
            for (int x = 0; x < _tasks.Count; x++) 
            {
                if (_tasks[x].DueDate.Date == DateTime.Now.Date) 
                {
                    Task_Item e = _tasks[x];
                    _todayList.Add(e);
                }

            }
        }




        private async void NavigateButton_OnClicked()
        {        
            await Shell.Current.GoToAsync("//ToDo");
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
            }
        }



            //Handle Data
        private TaskDB TaskListDB;

        private ObservableCollection<Task_Item> TodayList = new ObservableCollection<Task_Item>();

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

        public ObservableCollection<Task_Item> _todayList { get => TodayList; set { TodayList = value; OnPropertyChanged();}
        }
    }
}

    
