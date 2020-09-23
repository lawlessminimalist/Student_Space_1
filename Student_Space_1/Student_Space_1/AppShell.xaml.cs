using System;
using System.Collections.Generic;
using Student_Space.ViewModels;
using Student_Space.Views;
using Xamarin.Forms;

namespace Student_Space
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
