using Student_Space_1.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Student_Space.ViewModels
{
    public class CalendarWeekViewModel : BaseViewModel
    {
        public string month;
        CalendarWeek calendar;
  
        public ICommand GotoAddEvent { get; }
        public string CurrentMonth
        {
            get { return month; }
            set
            {
                month = value;
                OnPropertyChanged();
            }
        }

        public CalendarWeekViewModel(CalendarWeek calendar)
        {

            this.calendar = calendar;
            GotoAddEvent = new Command(OpenAddEvent);
        }

        async void OpenAddEvent()
        {
            await Shell.Current.GoToAsync(nameof(AddEvent));
        }




    }
}