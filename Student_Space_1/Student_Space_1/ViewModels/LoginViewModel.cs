using Student_Space;
using Student_Space_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

            //Access Shared Observable Collection (List of Students)
            StudentListDB = StudentDB.Instance;

            App.User = null;

        }

        //Command Function - Open Hi Q Contacts website 
        public async void OpenHelp()
        {
            string uri = "https://www.qut.edu.au/about/contact";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        /*
         * Command Function - Open the App after the user has logged
         * Password and Username are any strings, as long as not null user can log in 
         */
        public async void OpenApp()
        {

            try
            {
                bool loggedIn = false;
                while (loggedIn == false)
                {

                    foreach (Student user in ListStudent)
                    {
                        if (InputUser.Equals(user.ID) && InputPassword.Equals(user.Password))
                        {
                            App.User = user.ID;
                            Console.WriteLine("Logged in: " + user.Name);
                            break;
                        }

                    }


                    //Check the User 
                    if (App.User != null)
                    {
                        loggedIn = true;
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {

                        var answer = await App.Current.MainPage.DisplayAlert("Error", "You have entered an incorrect Username or Password", "Ok", "Logout");
                        if (answer)
                        {
                            return;
                        }
                        else
                        {
                            //Close the App
                            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Access List of Users
        //Handle Data
        private StudentDB StudentListDB;

        private ObservableCollection<Student> myVar;
        public ObservableCollection<Student> ListStudent //Bind this to the View
        {
            get { return StudentListDB.Studentlist; }
            set
            {
                myVar = value;
                OnPropertyChanged("ListStudent");
            }

        }

    }
}

/*if (InputUser.Equals(user.ID) && InputPassword.Equals(user.Password))
{

    Application.Current.MainPage = new AppShell();
    Console.WriteLine("Logged in: " + user.Name);
    loggedIn = true;
    break;
}
else if ((!InputUser.Equals(user.ID)) && (!InputPassword.Equals(user.Password)))
{
    Console.WriteLine("Casuing next error....... the heck " + user.Name);
    await App.Current.MainPage.DisplayAlert("Error", "You have entered an incorrect Username or Password", "Cancel");
}
*/


/*var result = ListStudent.Where(s => s.Name.Equals(InputUser) && s.Password.Equals(InputPassword));

var test = ListStudent.Where(s => s.Name.Equals(InputUser) && s.Password.Equals(InputPassword)).OfType<Student>().Select(Name => Name.Name).ToList();


if (result != null)
{

    Console.WriteLine("Found a user?" + result.ToList());
    Console.WriteLine("Name Test" + test);

    foreach (var student in result)
    {
        Console.WriteLine("Trying to get Student Name" + student.Name);
    }

    loggedIn = true;
}*/