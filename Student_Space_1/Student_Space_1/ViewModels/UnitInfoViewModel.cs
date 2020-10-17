using Student_Space_1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Student_Space_1.Models;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Student_Space.ViewModels
{
    public class UnitInfoViewModel : BaseViewModel
    {


        public ICommand PickerAlert4 { get; set; }
        public ObservableCollection<Announcement> Announcements{ get; set; }

        Announcement selectedAnnouncement;
        public Announcement SelectedAnnouncement
        {
            get { return selectedAnnouncement; }
            set
            {
                if (selectedAnnouncement != value)
                {
                    selectedAnnouncement = value;
                    OnPropertyChanged();
                }
            }
        }

        void MakeAlter()
        {
            Application.Current.MainPage.DisplayAlert("Alert", SelectedAnnouncement.AnnouncementInfo, "Cancel", "ok");
        }



        public UnitInfoViewModel()
        {

            Title = "Unit Information";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            PickerAlert4 = new Command(get => MakeAlter());
            SetupData();


    }




        public ICommand OpenWebCommand { get; }




        void SetupData()
        {
            Announcements = new ObservableCollection<Announcement>()
            {
                new Announcement
            {
                AnnouncementName = "Announcement numero uno",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero twqo",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero three",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero four",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                
            }

            };
        }




    }
}