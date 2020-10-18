using Student_Space_1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Student_Space.ViewModels
{
    public class UnitInfoViewModel : BaseViewModel
    {



        public ICommand PickerAlert4 { get; set; }
        public ObservableCollection<Announcement> Announcements{ get; set; }

        public ObservableCollection<Subject> Subjects { get; set; }

        public ObservableCollection<SubjectField> SubjectFieldsList { get; set; }

        public ObservableCollection<Announcement> DisplayAnnouncements = new ObservableCollection<Announcement>();

        private SubjectField _selectedField{ get; set; }

        public ObservableCollection<Announcement> GetAnnouncements
        {
            set
            {
                try
                {
                    if (DisplayAnnouncements != value)
                    {
                        DisplayAnnouncements = value;

                        DisplayAnnouncements = null;
                        OnPropertyChanged("GetAnnouncements");
                    }
                }
                catch (Exception ex)
                {
                    App.Current.MainPage.DisplayAlert("Alert", "something has gone wrong..." + ex, "Ok");
                }
            }
            get { return DisplayAnnouncements; }
        }


        public SubjectField SelectedField
        {
            get { return _selectedField; }
            set
            {
                if (_selectedField != value)
                {
                    _selectedField = value;

                    string field = _selectedField.SubjectFieldName;

                    DisplayAnnouncements.Clear();

                    foreach (var Announcement in Announcements)
                    {
                        try
                        {
                            if (Announcement.AnnouncementField == field)
                            {
                                DisplayAnnouncements.Add(Announcement);
                            }
                        }
                        catch (Exception ex)
                        {
                            App.Current.MainPage.DisplayAlert("Alert", "something has gone wrong..." + ex, "Ok");
                        }
                    }
                }
            }
        }

        private Announcement _selectedAnnouncement { get; set; }

        public Announcement SelectedAnnouncement
        {

            get { return _selectedAnnouncement; }
            set
            {
                if (_selectedAnnouncement != value)
                {
                    _selectedAnnouncement = value;
                    OnPropertyChanged();

                }
            }

        }

        
        void MakeAlter()
        {
            try
            {
                Application.Current.MainPage.DisplayAlert(SelectedAnnouncement.AnnouncementName, SelectedAnnouncement.AnnouncementInfo, "Cancel", "ok");

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Alert", "something has gone wrong..." + ex, "Ok");
            }
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
            
            Subjects = new ObservableCollection<Subject>()
            {

                new Subject{
                    SubjectID = "CAB203",
                    SubjectName ="Networks"

                },
                new Subject{
                    SubjectID = "CAB230",
                    SubjectName ="Cryptography"

                },
                new Subject{
                    SubjectID = "CAB302",
                    SubjectName ="Discrete Structures"

                },
                new Subject{
                    SubjectID = "IAB230",
                    SubjectName ="IT Management"

                }

            };


            SubjectFieldsList = new ObservableCollection<SubjectField>()
            {

                new SubjectField{
                    SubjectFieldName = "Announcement"

                },
                new SubjectField{
                    SubjectFieldName = "Lecture Recording"

                },
                new SubjectField{
                    SubjectFieldName = "Assignment"

                },
                new SubjectField{
                    SubjectFieldName = "Learning Resource"

                }


            };



            Announcements = new ObservableCollection<Announcement>()
            {
                new Announcement
            {
                AnnouncementName = "CAB303 exam is online only",
                AnnouncementInfo = "CAB303 exam is online only, please look at your individual ",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "CAB303"

            },
                new Announcement
            {
                AnnouncementName = "Exam 1 results have been released",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "CAB303"

            },
                new Announcement
            {
                AnnouncementName = "Announcement ",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "CAB303"

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero uno",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "CAB303"

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero uno",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "CAB340"

            },
                new Announcement
            {
                AnnouncementName = "Lecture recording week 1: ",
                AnnouncementInfo = "Your Week 1 lecture has been uploaded and can be seen at ",
                AnnouncementField = "Lecture Recording",
                AnnouncementSubject = "CAB303"

            }

            };


        }

        




}
}