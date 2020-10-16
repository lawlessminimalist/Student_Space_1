using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Student_Space.Services;
using Student_Space.Views;
using Student_Space_1.Views;


[assembly: ExportFont("JosefinSans-VariableFont_wght.ttf")]

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
            //Code Reference: https://github.com/xamarin/Xamarin.Forms/issues/10546
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
