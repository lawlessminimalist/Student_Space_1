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
        }

        public static TaskDB Instance { get; } = new TaskDB();

        private ObservableCollection<Task_Item> _list;
        public ObservableCollection<Task_Item> Mylist
        {
            get { return _list; }
            set { _list = value; }
        }
    }
}
