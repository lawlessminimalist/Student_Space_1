using Student_Space;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Student_Space_1.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        //Implement Property Change
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Declare Commands
        public ICommand UserLogin { get; }
        public ICommand GoHelp { get; }

        //Variables
        string InputUser = "";
        string InputPassword = "";

        //Getters and Setters for Password and Username
        private string username { get; set; }
        public string Username
        {
            get => username;
            set
            {
                if (value != null)
                {
                    username = value;
                    InputUser = username;
                    OnPropertyChanged("Username");
                }
            }
        }

        private string password { get; set; }
        public string Password
        {
            get => password;
            set
            {
                if (value != null)
                {
                    password = value;
                    InputPassword = password;
                    OnPropertyChanged("Password");
                }
            }
        }

 
        //Page Constructor
        public LoginViewModel()
        {
            UserLogin = new Command(OpenApp);
            GoHelp = new Command(OpenHelp);
        }

        //Command Function - Open Hi Q Contacs website 
        public async void OpenHelp()
        {
            string uri = "https://www.qut.edu.au/about/contact";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        /*
         * Command Function - Open the App after the user has logged
         * Password and Username are any strings, as long as not null user can log in 
         */
        async void OpenApp()
        {
            //Reference: https://stackoverflow.com/questions/54586621/whats-the-correct-way-to-implement-login-page-in-xamarin-shell

            if (String.IsNullOrWhiteSpace(InputUser) || String.IsNullOrWhiteSpace(InputPassword))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You have entered an incorrect Username or Password", "Ok");
            }
            else
            {
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}
