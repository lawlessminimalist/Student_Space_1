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


        public string _currentSubject;
        public string CurrentSubject
        {
            get { return _currentSubject; }
            set
            {
                _currentSubject = value;
                OnPropertyChanged(nameof(CurrentSubject));
            }
        }





        public bool _menu4isVisible = false;
        public bool _menu4isntVisible = true;

        public bool Menu4isVisible
        {
            get { return _menu4isVisible; }
            set
            {
                 _menu4isVisible = value;
                OnPropertyChanged(nameof(Menu4isVisible));
            }
        }

        public bool Menu4isntVisible
        {
            get { return _menu4isntVisible; }
            set
            {
                _menu4isntVisible = value;
                OnPropertyChanged(nameof(Menu4isntVisible));
            }
        }

        public void OpenMenu4()
        {
            if (Menu4isVisible == true)
            {
                Menu4isVisible = false;
                Menu4isntVisible = true;
            }
            else
            {
                Menu4isVisible = true;
                Menu4isntVisible = false;
                CurrentSubject = "IAB230";
            }
        }
        public ICommand Open4 { get; set; }



        public bool _menu3isVisible = false;
        public bool _menu3isntVisible = true;

        public bool Menu3isVisible
        {
            get { return _menu3isVisible; }
            set
            {
                _menu3isVisible = value;
                OnPropertyChanged(nameof(Menu3isVisible));
            }
        }

        public bool Menu3isntVisible
        {
            get { return _menu3isntVisible; }
            set
            {
                _menu3isntVisible = value;
                OnPropertyChanged(nameof(Menu3isntVisible));
            }
        }

        public void OpenMenu3()
        {
            if (Menu3isVisible == true)
            {
                Menu3isVisible = false;
                Menu3isntVisible = true;
            }
            else
            {
                Menu3isVisible = true;
                Menu3isntVisible = false;
                CurrentSubject = "CAB302";
            }
        }
        public ICommand Open3 { get; set; }



        public bool _menu2isVisible = false;
        public bool _menu2isntVisible = true;

        public bool Menu2isVisible
        {
            get { return _menu2isVisible; }
            set
            {
                _menu2isVisible = value;
                OnPropertyChanged(nameof(Menu2isVisible));
            }
        }

        public bool Menu2isntVisible
        {
            get { return _menu2isntVisible; }
            set
            {
                _menu2isntVisible = value;
                OnPropertyChanged(nameof(Menu2isntVisible));
            }
        }

        public void OpenMenu2()
        {
            if (Menu2isVisible == true)
            {
                Menu2isVisible = false;
                Menu2isntVisible = true;
            }
            else
            {
                Menu2isVisible = true;
                Menu2isntVisible = false;
                CurrentSubject = "CAB230";
            }
        }
        public ICommand Open2 { get; set; }





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
                                if (Announcement.AnnouncementSubject == CurrentSubject)
                                {
                                    DisplayAnnouncements.Add(Announcement);
                                }
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

            //Title = "Unit Information";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            PickerAlert4 = new Command(get => MakeAlter());
            Open4 = new Command(get => OpenMenu4());
            Open3 = new Command(get => OpenMenu3());
            Open2 = new Command(get => OpenMenu2());
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
                AnnouncementSubject = "IAB230"

            },
                new Announcement
            {
                AnnouncementName = "Exam 1 results have been released",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "IAB230"

            },
                new Announcement
            {
                AnnouncementName = "Announcement ",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "IAB230"

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero uno",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "IAB230"

            },
                new Announcement
            {
                AnnouncementName = "Announcement numero uno",
                AnnouncementInfo = "This is the first announcement info page i really don tknow what else to write on this",
                AnnouncementField = "Announcement",
                AnnouncementSubject = "CAB302"

            },
                new Announcement
            {
                AnnouncementName = "Lecture recording week 1: ",
                AnnouncementInfo = "Your Week 1 lecture has been uploaded and can be seen at ",
                AnnouncementField = "Lecture Recording",
                AnnouncementSubject = "IAB230"

            }

            };


        }

        




}
}