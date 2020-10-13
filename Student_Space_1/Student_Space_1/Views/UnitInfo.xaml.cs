using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Space_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitInfo : ContentPage
    {
        public UnitInfo()
        {
            InitializeComponent();


        }

        private void Open11(object sender, EventArgs e)
        {
            if (MenuOpen11.IsVisible == true)
            {
                MenuOpen11.IsVisible = false;
                MenuOpen1.IsVisible = true;

            }
            else
            {
                MenuOpen11.IsVisible = true;
                MenuOpen1.IsVisible = false;
                MenuOpen12.IsVisible = false;
                MenuOpen13.IsVisible = false;
                MenuOpen14.IsVisible = false;
            }

        }
        private void Open12(object sender, EventArgs e)
        {
            if (MenuOpen12.IsVisible == true)
            {
                MenuOpen12.IsVisible = false;
                MenuOpen1.IsVisible = true;

            }
            else
            {
                MenuOpen12.IsVisible = true;
                MenuOpen1.IsVisible = false;
                MenuOpen11.IsVisible = false;
                MenuOpen13.IsVisible = false;
                MenuOpen14.IsVisible = false;

            }

        }
        private void Open13(object sender, EventArgs e)
        {
            if (MenuOpen13.IsVisible == true)
            {
                MenuOpen13.IsVisible = false;
                MenuOpen1.IsVisible = true;

            }
            else
            {
                MenuOpen13.IsVisible = true;
                MenuOpen1.IsVisible = false;
                MenuOpen11.IsVisible = false;
                MenuOpen12.IsVisible = false;
                MenuOpen14.IsVisible = false;
            }

        }

        private void Open14(object sender, EventArgs e)
        {
            if (MenuOpen14.IsVisible == true)
            {
                MenuOpen14.IsVisible = false;
                MenuOpen1.IsVisible = true;

            }
            else
            {
                MenuOpen14.IsVisible = true;
                MenuOpen1.IsVisible = false;
                MenuOpen11.IsVisible = false;
                MenuOpen12.IsVisible = false;
                MenuOpen13.IsVisible = false;
                MenuOpen14.IsVisible = false;
            }

        }

        private void Open1(object sender, EventArgs e)
        {
            if (MenuOpen1.IsVisible == true)
            {
                MenuOpen1.IsVisible = false;
            }
            else
            {
                MenuOpen1.IsVisible = true;
            }

        }

        private void Open3(object sender, EventArgs e)
        {
            if (MenuOpen.IsVisible == true)
            {
                MenuOpen.IsVisible = false;
            }
            else
            {
                MenuOpen.IsVisible = true;
            }

        }

        private void Open4(object sender, EventArgs e)
        {
            if (MenuOpen.IsVisible == true)
            {
                MenuOpen.IsVisible = false;
            }
            else
            {
                MenuOpen.IsVisible = true;
            }


            /*
            if (4Menu.IsVisible == true)
            {
                4Menu.IsVisible = false;
            
            }
            else
            {
                4Menu.IsVisible = true;

            }
            */

        }

        
        private void OpenAnnounce(object sender, EventArgs e)
        {
            if (PopupAnnouncement.IsVisible == true)
            {
                PopupAnnouncement.IsVisible = false;
            }
            else
            {
                PopupAnnouncement.IsVisible = true;
            }

        }
        

        async void OnDisplayAlertButtonClicked2031(object sender, EventArgs e)
        {
            await DisplayAlert("CAB 203 Announcement number 1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Close");
        }

        async void OnDisplayAlertButtonClicked2032(object sender, EventArgs e)
        {
            await DisplayAlert("CAB 203 Announcement number 2", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Close");
        }

        async void OnDisplayAlertButtonClicked2033(object sender, EventArgs e)
        {
            await DisplayAlert("CAB 203 Announcement number 3", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Close");
        }

        async void OnDisplayAlertButtonClicked2034(object sender, EventArgs e)
        {
            await DisplayAlert("CAB 203 Announcement number 4", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", "Close");
        }

        async void OnDisplayAlertQuestionButtonClicked(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Save?", "Would you like to save your data?", "Yes", "No");
            Console.WriteLine("Save data: " + response);
        }


        

    }
}