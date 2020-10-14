using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


using System.Collections.Generic;
using System.Text;
using Student_Space_1.Models;
using System.Collections.ObjectModel;
using Student_Space_1.Views;

using System.Runtime.CompilerServices;

namespace Student_Space.ViewModels
{
    public class UnitContactViewModel : INotifyPropertyChanged
    {
        //Create Collections to Store Objects
        public ObservableCollection<Units> UnitContactList { get; set; } 
        public ObservableCollection<UnitContactDetails> ContactDetails { get; set; }

        private ObservableCollection<UnitContactDetails> DisplayContacts = new ObservableCollection<UnitContactDetails>();

        //Implement Property Change
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //Getters and Setters for Lists 
        public ObservableCollection<UnitContactDetails> GetContacts
        {
            set
            {
                try
                {
                    if (DisplayContacts != value)
                    {
                        DisplayContacts = value;
                        OnPropertyChanged("GetContacts");
                    }
                }
                catch (Exception ex)
                {
                    App.Current.MainPage.DisplayAlert("Alert", "something has gone wrong..." + ex, "Ok");
                }
            }
            get { return DisplayContacts; }
        }

        //Get the Selected Unit from Picker
        private Units _selectedUnit { get; set; }

        /* Get the Select Unit and Update the Display List to only contain Contacts the User has selected
         */
        public Units SelectedUnit 
        {
            get { return _selectedUnit; }
            set
            {
                if (_selectedUnit != value)
                {
                    _selectedUnit = value;

                    string code = _selectedUnit.UnitCode;

                    //Clear the Display List
                    DisplayContacts.Clear();

                    //Get the Units Matching the Selected Unit Code
                    foreach (var contact in ContactDetails)
                    {
                        try
                        {
                            if (contact.Code == code)
                            {
                                //Populate the Display List
                                DisplayContacts.Add(contact);
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


        //Constructor
        public UnitContactViewModel()
        {
            SetupData();
        }

        //Helper Function that returns specific format for Image to be Displayed
        public ImageSource Image(string IconSource)
        {
            return ImageSource.FromResource(string.Format("Student_Space_1.PeopleImages.{0}", IconSource));
        }

        //Mock Data
        void SetupData()
        {
            //List of Student's Current Units
            UnitContactList = new ObservableCollection<Units>()
            {
                new Units
                {
                    UnitCode = "IFB295",
                    UnitName = "Project Management"
                },

                new Units
                {
                    UnitCode = "IAB330",
                    UnitName = "Mobile Application Development"
                },

                new Units
                {
                    UnitCode = "CAB303",
                    UnitName = "Networks"
                },

                new Units
                {
                    UnitCode = "IAB201",
                    UnitName = "Modelling Techniques for Information Systems"
                }
            };


            //List containing Staff Contact Details (Name, Postion, Photo, Office, Email, Unit Code, Image) 
            ContactDetails = new ObservableCollection<UnitContactDetails>()
            {
                new UnitContactDetails
                {
                    Name = "Amy Phillips",
                    Email = "amy.phillips@connect.qut.edu.au",
                    Position = "Lectuer",
                    OfficeLocation = "Z123",
                    Contact_Picture = Image("Amy.jpg"),
                    Code = "CAB303"
                },

                new UnitContactDetails
                {
                    Name = "Andrew Williams",
                    Email = "andrew.williams@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "Z234",
                    Contact_Picture = Image("Andrew.jpg") ,
                    Code = "CAB303"
                },

                new UnitContactDetails
                {
                    Name = "Dan Rose",
                    Email = "dan.rose@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "C123",
                    Contact_Picture = Image("Dan.jpg"),
                    Code = "CAB303"
                },

                new UnitContactDetails
                {
                    Name = "Frank Tiles",
                    Email = "frank.tiles@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "O985",
                    Contact_Picture = Image("Frank.jpeg"),
                    Code = "CAB303"
                },

                ///////////////////////////////////////////////////////////////////
                new UnitContactDetails
                {
                    Name = "John Holmes",
                    Email = "John.Holmes@connect.qut.edu.au",
                    Position = "Lectuer",
                    OfficeLocation = "Z123",
                    Contact_Picture = Image("John.jpg"),
                    Code = "IFB295"
                },

                new UnitContactDetails
                {
                    Name = "Ken Ken",
                    Email = "Ken.Ken@connect.qut.edu.au",
                    Position = "Unit Coordinator",
                    OfficeLocation = "Z104",
                    Contact_Picture = Image("Ken.jpg"),
                    Code = "IFB295"
                },

                new UnitContactDetails
                {
                    Name = "Lily Bloom",
                    Email = "Lily.Bloom@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "P182",
                    Contact_Picture = Image("Lily.png"),
                    Code = "IFB295"
                },

                new UnitContactDetails
                {
                    Name = "Maggie Li",
                    Email = "Maggie.Li@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "C456",
                    Contact_Picture = Image("Maggie.jpg"),
                    Code = "IFB295"
                },

                ///////////////////////////////////////////////////////////////////
                new UnitContactDetails
                {
                    Name = "Mark Filer",
                    Email = "Mark.Filer@connect.qut.edu.au",
                    Position = "Unit Coordinator & Lectuer",
                    OfficeLocation = "A678",
                    Contact_Picture = Image("Mark.jfif"),
                    Code = "IAB201"
                },

                new UnitContactDetails
                {
                    Name = "Peter Endo",
                    Email = "Peter.Endo@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "Z234",
                    Contact_Picture = Image("Peter.jfif") ,
                    Code = "IAB201"
                },

                new UnitContactDetails
                {
                    Name = "Steve Foxy",
                    Email = "Steve.Foxy@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "C123",
                    Contact_Picture = Image("Steve.jfif") ,
                    Code = "IAB201"
                },

                new UnitContactDetails
                {
                    Name = "Tony Hawk",
                    Email = "Tony.Hawk@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "O985",
                    Contact_Picture = Image("Tony.jfif"),
                    Code = "IAB201"
                },
                ///////////////////////////////////////////////////////////////
                new UnitContactDetails
                {
                    Name = "George Kelly",
                    Email = "George.Kelly@connect.qut.edu.au",
                    Position = "Unit Coordinator & Lectuer",
                    OfficeLocation = "K987",
                    Contact_Picture = Image("George.jpg"),
                    Code = "IAB330"
                },

                new UnitContactDetails
                {
                    Name = "Daffy Flowers",
                    Email = "Daffy.Flowers@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "P799",
                    Contact_Picture = Image("Daffy.jpeg") ,
                    Code = "IAB330"
                },

                new UnitContactDetails
                {
                    Name = "Paul News",
                    Email = "Paul.News@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "L678",
                    Contact_Picture = Image("Paul.jpg"),
                    Code = "IAB330"
                },

                new UnitContactDetails
                {
                    Name = "Vesna Sparrow",
                    Email = "Vesna.Sparrow@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "H678",
                    Contact_Picture = Image("Vesna.jpg"),
                    Code = "IAB330"
                },
            };


            //Copy Get Contacts to Display Contacts
            foreach (var contact in ContactDetails)
            {
                //Add to Get Contacts 
                DisplayContacts.Add(contact);
            }

        }

    }
}