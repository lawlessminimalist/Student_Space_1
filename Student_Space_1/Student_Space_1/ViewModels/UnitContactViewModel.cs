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
        //Create Lists to Store Objects
        public ObservableCollection<Units> UnitContactList { get; set; }
        public ObservableCollection<UnitContactDetails> ContactDetails { get; set; }

        private ObservableCollection<UnitContactDetails> DisplayContacts = new ObservableCollection<UnitContactDetails>();

        //Implement Property Change
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
                    Console.WriteLine("Exception We Dieeeeeee!!!!!!!!!!!!" + ex);
                }
            }

            get { return DisplayContacts; }
        }

        //Get the Selected Unit
        private Units _selectedUnit { get; set; }
        public Units SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                if (_selectedUnit != value)
                {
                    _selectedUnit = value;
                    //Do What Ever Functionanility you Want Here!!
                    string code = _selectedUnit.UnitCode;

                    //App.Current.MainPage.DisplayAlert("Alert", code + " nearly there.... ", "Ok");  For Testing Purposes 

                    //Clear the Display List
                    DisplayContacts.Clear();

                    //Get the Unit Code
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
                        catch (Exception Ex)
                        {
                            Console.WriteLine("Something Bad has Happened AiYaaaaaaaaaaaaa" + Ex.ToString());
                        }
                    }
                }

                //Testing Display 
                for (int i = 0; i < DisplayContacts.Count; i++)
                {
                    Console.WriteLine(string.Concat(DisplayContacts[i].Name, "---", DisplayContacts[i].Code, "---", DisplayContacts[i].Position));
                }
            }
        }



        public UnitContactViewModel()
        {
            SetupData();
            //Title = "Unit Contacts";
            //UnitSelected = new Command(DisplayContacts);
            //Get Selected User If there is One
            OnPropertyChanged("DisplayContacts");

        }

        //Set Up Mock Unit Contact Data
        void SetupData()
        {
            //List of Units
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


            //List containing Contact Details (Name, Postion, Photo, Office, Email, Unit Code, Image) 
            ContactDetails = new ObservableCollection<UnitContactDetails>()
            {
                new UnitContactDetails
                {
                    Name = "Amy Phillips",
                    Email = "amy.phillips@connect.qut.edu.au",
                    Position = "Lectuer",
                    OfficeLocation = "Z123",
                    Contact_Picture = new Image{ Source = "Amy.jpg" },
                    Code = "CAB303"
                },

                new UnitContactDetails
                {
                    Name = "Andrew Williams",
                    Email = "andrew.williams@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "Z234",
                    Contact_Picture = new Image{ Source = "Andrew.jpg" },
                    Code = "CAB303"
                },

                new UnitContactDetails
                {
                    Name = "Dan Rose",
                    Email = "dan.rose@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "C123",
                    Contact_Picture = new Image{ Source = "Dan.jpg" },
                    Code = "CAB303"
                },

                new UnitContactDetails
                {
                    Name = "Frank Tiles",
                    Email = "frank.tiles@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "O985",
                    Contact_Picture = new Image{ Source = "Frank.jpg" },
                    Code = "CAB303"
                },

                ///////////////////////////////////////////////////////////////////
                new UnitContactDetails
                {
                    Name = "John Holmes",
                    Email = "John.Holmes@connect.qut.edu.au",
                    Position = "Lectuer",
                    OfficeLocation = "Z123",
                    Contact_Picture = new Image{ Source = "John.jpg" },
                    Code = "IFB295"
                },

                new UnitContactDetails
                {
                    Name = "Ken Ken",
                    Email = "Ken.Ken@connect.qut.edu.au",
                    Position = "Unit Coordinator",
                    OfficeLocation = "Z104",
                    Contact_Picture = new Image{ Source = "Ken.jpg" },
                    Code = "IFB295"
                },

                new UnitContactDetails
                {
                    Name = "Lily Bloom",
                    Email = "Lily.Bloom@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "P182",
                    Contact_Picture = new Image{ Source = "Dan.jpg" },
                    Code = "IFB295"
                },

                new UnitContactDetails
                {
                    Name = "Maggie Li",
                    Email = "Maggie.Li@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "C456",
                    Contact_Picture = new Image{ Source = "Frank.jpg" },
                    Code = "IFB295"
                },

                ///////////////////////////////////////////////////////////////////
                new UnitContactDetails
                {
                    Name = "Mark Filer",
                    Email = "Mark.Filer@connect.qut.edu.au",
                    Position = "Unit Coordinator & Lectuer",
                    OfficeLocation = "A678",
                    Contact_Picture = new Image{ Source = "Amy.jpg" },
                    Code = "IAB201"
                },

                new UnitContactDetails
                {
                    Name = "Peter Endo",
                    Email = "Peter.Endo@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "Z234",
                    Contact_Picture = new Image{ Source = "Andrew.jpg" },
                    Code = "IAB201"
                },

                new UnitContactDetails
                {
                    Name = "Steve Foxy",
                    Email = "Steve.Foxy@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "C123",
                    Contact_Picture = new Image{ Source = "Dan.jpg" },
                    Code = "IAB201"
                },

                new UnitContactDetails
                {
                    Name = "Tony Hawk",
                    Email = "Tony.Hawk@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "O985",
                    Contact_Picture = new Image{ Source = "Frank.jpg" },
                    Code = "IAB201"
                },
                ///////////////////////////////////////////////////////////////
                new UnitContactDetails
                {
                    Name = "George Kelly",
                    Email = "George.Kelly@connect.qut.edu.au",
                    Position = "Unit Coordinator & Lectuer",
                    OfficeLocation = "K987",
                    Contact_Picture = new Image{ Source = "George.jpg" },
                    Code = "IAB330"
                },

                new UnitContactDetails
                {
                    Name = "Daffy Flowers",
                    Email = "Daffy.Flowers@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "P799",
                    Contact_Picture = new Image{ Source = "Daffy.jpg" },
                    Code = "IAB330"
                },

                new UnitContactDetails
                {
                    Name = "Paul News",
                    Email = "Paul.News@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "L678",
                    Contact_Picture = new Image{ Source = "Dan.jpg" },
                    Code = "IAB330"
                },

                new UnitContactDetails
                {
                    Name = "Vesna Sparrow",
                    Email = "Vesna.Sparrow@connect.qut.edu.au",
                    Position = "Tutor",
                    OfficeLocation = "H678",
                    Contact_Picture = new Image{ Source = "Frank.jpg" },
                    Code = "IAB330"
                },
            };


            //Copy Get Contacts
            foreach (var contact in ContactDetails)
            {
                //Add to Get Contacts 
                DisplayContacts.Add(contact);
            }

        }

    }
}