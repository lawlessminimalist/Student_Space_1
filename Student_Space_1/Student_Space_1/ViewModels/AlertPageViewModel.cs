using Student_Space_1.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace Student_Space.ViewModels
{
    public class AlertPageViewModel : BindableObject
    {

        public ICommand AddTask { get; }
        public ICommand DeleteTask { get; }

        public ObservableCollection<Task_Item> _Tasks = new ObservableCollection<Task_Item>(); //Initialize List



        public AlertPageViewModel()
        {

            Setup();
            AddTask = new Command(AddItem);
            DeleteTask = new Command(DeleteItem);
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

            //Open Alert Message to Ask for What Task
            string result = await App.Current.MainPage.DisplayPromptAsync("Add Task", "What did you want to do?", "Add", "Cancel");

            //Create a New Task
            Task_Item new_task = new Task_Item
            {
                TaskName = result,
            };

            //Add Task to List of Tasks 
            Tasks.Add(new_task);

        }

        void DeleteItem(object item)
        {
            //Remove Item from To Do List

            var task = item as Task_Item;
            Tasks.Remove(task);
        }

        //Fake Data for Easier Testing
        void Setup()
        {
            Tasks = new ObservableCollection<Task_Item>
            {
                new Task_Item
                {
                    TaskName = "Hello",

                },

                 new Task_Item
                {
                    TaskName = "Watch Lecture 2000",

                },

                 new Task_Item
                {
                    TaskName = "Watch Lecture 12312312",

                },
                 new Task_Item
                {
                    TaskName = "Watch Lecture 12312312",

                },

            };
        }

    }
}

    
