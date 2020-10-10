using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Student_Space.ViewModels
{
    public class AlertPageViewModel : BaseViewModel
    {
        public AlertPageViewModel()
        {
            Title = "Student Space";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));


        }

        public ICommand OpenWebCommand { get; }
    }
}