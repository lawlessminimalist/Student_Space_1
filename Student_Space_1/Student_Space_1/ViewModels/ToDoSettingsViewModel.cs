using Student_Space_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Student_Space.ViewModels;
using MvvmHelpers;
using System.Windows.Input;
using Student_Space;
using System.Collections.Specialized;
using System.Globalization;
using Student_Space_1.Views;

namespace Student_Space_1.ViewModels
{
    [QueryProperty(nameof(TaskSetting), nameof(TaskSetting))]

    class ToDoSettingsViewModel : MvvmHelpers.BaseViewModel, INotifyPropertyChanged
    {
        //Implement Property Change
        public new event PropertyChangedEventHandler PropertyChanged;
        private new void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Declare Commands
        public ICommand EditTask { get; }
        public ICommand SaveTask { get; }


        //Collection to Store Colours
        public ObservableCollection<Colour> ColourList { get; set; }


        //Variables for the Page to Display (Name, Colour, Date, Reminder, Notes)
        private string name { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (value != null)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }    
            }
        }

        private string notes { get; set; }
        public string UserNotes
        {
            get => notes;
            set
            {
                if (value != null)
                {
                    notes = value;
                    OnPropertyChanged("UserNotes");
                }
            }
        }

        //Get Selected Colour from Picker
        private Colour _selectedColour { get; set; }
        public Colour SelectedColour
        {
            get { return _selectedColour; }
            set
            {
                if (_selectedColour != value)
                {
                    _selectedColour = value;

                    Colour = _selectedColour.hexValue; //Get Colour Hex Value
                }
            }
        }

        
        //Get Hex Value and Update
        private string _colour { get; set; }
        public string Colour
        {
            get => _colour;
            set
            {
                if (value != null)
                {
                    _colour = value;
                    OnPropertyChanged("Colour");
                }
            }
        }

        //Get Selected Display Time
        private TimeSpan _time { get; set; }
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        //Get Selected Time from Picker
        private TimeSpan _selectedTime { get; set; }
        public TimeSpan SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                if (_selectedTime != value)
                {
                    _selectedTime = value;
                    Time = _selectedTime;
                }
            }
        }

        //Get Date for Display
        private DateTime _date { get; set; }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        //Get Selected Date from Picker
        private DateTime _selectedDate { get; set; }
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    Date = _selectedDate;
                }
            }
        }

        //Get Selected Radio Button [Experimental, Added Flags]
        private string _selectedRadio;
        public string SelectedRadio
        {
            get { return _selectedRadio; }
            set
            {
                _selectedRadio = value;
                OnPropertyChanged("SelectedRadio");
                Reminder = _selectedRadio;
            }
        }

        //Get and Set Reminder Value (Radio Button)
        private string _reminder { get; set; }
        public string Reminder
        {
            get { return _reminder; }
            set
            {
                if (_reminder != value)
                {
                    _reminder = value;
                    OnPropertyChanged("Reminder");
                }
            }
        }
 
        //Get the Selected Task (Data passed from Preivous Page
        public Task_Item _selectedTask { get; set; }

        //Function to return Object
        public Task_Item Select(string name)
        {

            Task_Item selected = null;

            //Find Object matching selected task name from list
            foreach (Task_Item task in ToDoTasks)
            {
                if (task.TaskName.Equals(name))
                {
                    selected = task;
                }

            }

            return selected;
        }

        //Get Selected Task Name and Assingment Default Values to Repsective Getter and Setter
        private string _TaskSetting = "";
        public string TaskSetting
        {   get => _TaskSetting; 
            set 
            {
                _TaskSetting = Uri.UnescapeDataString(value ?? string.Empty); 
                OnPropertyChanged("TaskSetting");

                _selectedTask = Select(_TaskSetting);

                //Assign Variables to Task Properties 
                Name = _selectedTask.TaskName;
                Colour = _selectedTask.Priority;
                Time = _selectedTask.DueTime;
                Date = _selectedTask.DueDate;
                Reminder = _selectedTask.Reminders;
                UserNotes = _selectedTask.Notes;

            }
        }

        //Helper Funcion for Radio Buttons
        public RadioHelper RadioButtonCommand
        {
            get
            {
                return new RadioHelper((p) =>
                {
                    SelectedRadio = (string)p;
                });
            }
        }

        //Edit Task Name 
        async void Edit()
        {

            //Open Alert Message to Ask for the new Name
            string result = await App.Current.MainPage.DisplayPromptAsync("Edit Task", "What is your new Task called?", "Save", "Cancel");

            //Update the TaskName in Collection Works
            _selectedTask.TaskName = result;
            Name = result; 
        }


        //Update List by Remove and Adding a New Item
        /*Notes: UI on To Do List Page would not Update upon changes to objects in the collection despite having INotifyPropertyChanged --> did research 
         * --> nothing worked despite the list changing (tested with debug)
         * --> further research the Observable Collection only updates on add or remove changes to list
         * --> There may be a better method, however, this method is the only method that seemed to work . . .
         * */
        public void UpdateList()
        {
            try
            {
                //Create New Task using Inputting Data
                Task_Item update_task = new Task_Item
                {
                    TaskName = Name,
                    DueTime = Time,
                    DueDate = Date,
                    Priority = Colour,
                    Notes = UserNotes,
                    Reminders = Reminder,
                };

                //Delete the Selected Task
                ToDoTasks.Remove(_selectedTask);

                //Add the New Task
                ToDoTasks.Add(update_task);


                //Go Back to Previous Page
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error!", "Something went wrong!" + ex, "Ok");
            }

        }

        //Constructor
        public ToDoSettingsViewModel()
        {
            //Set Up Data
            SetUp();
            TaskListDB = TaskDB.Instance;

            //Comands 
            EditTask = new Command(Edit);
            SaveTask = new Command(UpdateList);

            Title = "To Do List Settings";

        }

        //Data Handling 
        private TaskDB TaskListDB;

        //Enable Settings Page to Read Items from To Do List to get Details
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

        //Add List of Colours to List
        public void SetUp()
        {

            ColourList = new ObservableCollection<Colour>()
            {
                new Colour
                {
                    ColourName = "Black",
                    hexValue = "#212121",
                },

                new Colour
                {
                    ColourName = "Blue Grey",
                    hexValue = "#607D8B",
                },

                new Colour
                {
                    ColourName = "Cyan",
                    hexValue = "#00BCD4",
                },

                new Colour
                {
                    ColourName = "Dark Purple",
                    hexValue = "#673AB7",
                },

                new Colour
                {
                    ColourName = "Grey",
                    hexValue = "#9E9E9E",
                },

                new Colour
                {
                    ColourName = "Light Blue",
                    hexValue = "#AED6F1",
                },

                new Colour
                {
                    ColourName = "Lime",
                    hexValue = "#CDDC39",
                },

                new Colour
                {
                    ColourName = "Pink",
                    hexValue = "#E91E63",
                },

                new Colour
                {
                    ColourName = "Red",
                    hexValue = "#D32F2F",
                },

                new Colour
                {
                    ColourName = "Amber",
                    hexValue = "#FFC107",
                },

                new Colour
                {
                    ColourName = "Blue",
                    hexValue = "#2196F3",
                },

                new Colour
                {
                    ColourName = "Brown",
                    hexValue = "#795548",
                },

                new Colour
                {
                    ColourName = "Green",
                    hexValue = "#07DA63",
                },

                new Colour
                {
                    ColourName = "Purple",
                    hexValue = "#94499D",
                },

                new Colour
                {
                    ColourName = "Teal",
                    hexValue = "#03D5C8",
                },

                new Colour
                {
                    ColourName = "Orange",
                    hexValue = "#FF9800",
                },

                new Colour
                {
                    ColourName = "Light Green",
                    hexValue = "#8AC249",
                },

                new Colour
                {
                    ColourName = "Peacock Blue",
                    hexValue = "#6EB5FF",
                },

                new Colour
                {
                    ColourName = "Sunset",
                    hexValue = "#FFCBC1",
                },

                new Colour
                {
                    ColourName = "Princess Pink",
                    hexValue = "#FFCCF9",
                },

                new Colour
                {
                    ColourName = "Mermaid Green",
                    hexValue = "#CCFFCC",
                },

                new Colour
                {
                    ColourName = "Salmon",
                    hexValue = "#FA8072",
                },



                new Colour
                {
                    ColourName = "Midnight Blue",
                    hexValue = "#191970",
                },

                new Colour
                {
                    ColourName = "Blood Red",
                    hexValue = "#8b0000",
                },

                new Colour
                {
                    ColourName = "Sand",
                    hexValue = "#fff68f",
                },

                new Colour
                {
                    ColourName = "Forest Green",
                    hexValue = "#008080",
                },
            };

        }


    }
}


