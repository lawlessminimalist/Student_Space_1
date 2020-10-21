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
        public int firstdayofweek;
        CalendarMonth calendar;

        public ICommand GoToCurrentWeek { get; }
        public ICommand AddEvent { get; }

        public int firstdayofweekselected
        {
            get { return firstdayofweek;  }
            set
            {
                firstdayofweek = value;
                OnPropertyChanged();
            }
        }
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

            this.calendar = calendar;
            GoToCurrentWeek = new Command(OpenCalendarWeek);
            AddEvent = new Command(OpenAddEvent);
        }

        async void OpenAddEvent()
        {
            await Shell.Current.GoToAsync(nameof(AddEvent));
        }

        async void OpenCalendarWeek()
        {
            await Shell.Current.GoToAsync(nameof(CalendarWeek));
        }


        



    }
}