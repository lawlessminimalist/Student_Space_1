using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Student_Space.Services;
using Student_Space.Views;
using Student_Space_1.Views;

namespace Student_Space
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();

            MainPage = new NavigationPage(new Login());

            //Set Experimental Flags for Radio Buttons
            Device.SetFlags(new[]
            {
                "RadioButton_Experimental",
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
