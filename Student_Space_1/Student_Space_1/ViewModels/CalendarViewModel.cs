using Student_Space_1.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Student_Space.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        public string month;
        CalendarMonth calendar;
        public Command<string> PreviousCalendarCommand { get; }
        public Command<string> NextCalendarCommand { get; }
        public string CurrentMonth
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged();
                PreviousCalendarCommand.ChangeCanExecute();
                NextCalendarCommand.ChangeCanExecute();
            }
        }

        public CalendarViewModel(CalendarMonth calendar)
        {

            this.calendar = calendar;
            PreviousCalendarCommand = new Command<string>(Prev, CanExecute);
            NextCalendarCommand = new Command<string>(Next, CanExecute);
        }

        public bool CanExecute(string arg)
        {
            bool isEnabled = true;
            return isEnabled;
        }

        public void Prev(string arg)
        {
            calendar.DateNow.AddMonths(-1);
        }

        public void Next(string changeType)
        {
            calendar.DateNow.AddMonths(+1);
        }
        public ICommand OpenWebCommand { get; }

        



    }
}