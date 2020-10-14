using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Student_Space_1.Models
{
    class TaskDB
    {
        //Reference: https://stackoverflow.com/questions/59725322/xamarin-mvvm-pass-data-to-other-viewmodels-and-shared-viewmodel

        //Using Singleton Pattern
        private TaskDB()
        {
            //Initalize Collection
            _list = new ObservableCollection<Task_Item>();

            try
            {
                SetupData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static TaskDB Instance { get; } = new TaskDB();

        private ObservableCollection<Task_Item> _list;
        public ObservableCollection<Task_Item> Mylist
        {
            get { return _list; }
            set { _list = value; }
        }


        //Add Some dummy Data to the List (User can still add Tasks) 
        public void SetupData()
        {
            Task_Item new_task1 = new Task_Item
            {
                TaskName = "Watch IAB330 Lecture 12",
                DueDate = DateTime.Today,
                DueTime = new TimeSpan(15, 30, 00),
                Priority = "#D32F2F",
                Notes = "Important Lecture for the Assignment",
                Reminders = null,
            };

            Task_Item new_task2 = new Task_Item
            {
                TaskName = "Submit Resume to Yahoo!",
                DueDate = DateTime.Today,
                DueTime = new TimeSpan(18, 30, 00),
                Priority = "#CCFFCC",
                Notes = "Need to Find a job",
                Reminders = null,
            };

            Task_Item new_task3 = new Task_Item
            {
                TaskName = "Impolement App Error Handling",
                DueDate = DateTime.Today,
                DueTime = new TimeSpan(15, 30, 00),
                Priority = "#03D5C8",
                Notes = "Must do",
                Reminders = null,
            };

            _list.Add(new_task1);
            _list.Add(new_task2);
            _list.Add(new_task3);
        }
    }
}
