using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


using Student_Space_1.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Space.ViewModels
{
    public class GradesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AllUnits> StudentUnits { get; set; } //Contains a List of the Student's Units 
        public ObservableCollection<Assessment> AssessmentList { get; set; } //Contains a List of the Student's Units 

        private ObservableCollection<Assessment> DisplayGrades = new ObservableCollection<Assessment>();

        public string course { get; set; }
        public string GPA { get; set; }


        //Event Signature for Butter Hyperlink


        //Implement Property Change
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Assessment> GetGrades
        {
            set
            {
                try
                {
                    if (DisplayGrades != value)
                    {
                        DisplayGrades = value;
                        OnPropertyChanged("GetGrades");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception We Dieeeeeee!!!!!!!!!!!!" + ex);
                }
            }

            get { return DisplayGrades; }
        }

        //Get the Selected Unit
        private AllUnits _selectedUnit { get; set; }
        public AllUnits SelectedUnit
        {
            get { return _selectedUnit; }
            set
            {
                if (_selectedUnit != value)
                {
                    _selectedUnit = value;
                    //Do What Ever Functionanility you Want Here!!
                    string code = _selectedUnit.UnitCode;

                    //App.Current.MainPage.DisplayAlert("Alert", code + " I have No Idea what is going on gg", "Ok");

                    //Clear the Display List
                    DisplayGrades.Clear();

                    //Get the Unit Code
                    foreach (var piece in AssessmentList)
                    {
                        try
                        {
                            if (piece.Code == code)
                            {
                                //Populate the Display List
                                DisplayGrades.Add(piece);
                            }
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("Something Bad has Happened AiYaaaaaaaaaaaaa" + Ex.ToString());
                        }
                    }
                }

                Total = _selectedUnit.Grade;
                Percentage = _selectedUnit.Percentage;

                //Testing Display 
                for (int i = 0; i < DisplayGrades.Count; i++)
                {
                    Console.WriteLine(string.Concat(DisplayGrades[i].AssessmentName, "---", DisplayGrades[i].Mark, "------", Percentage, "----", Total));
                }
            }
        }

        public string _total;

        public string Total
        {
            get { return _total; }

            set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _percentage;

        public string Percentage
        {
            get { return _percentage; }

            set
            {
                if (_percentage != value)
                {
                    _percentage = value;
                    OnPropertyChanged();
                }
            }
        }

        public GradesViewModel()
        {
            SetUpData();
            Total = "N/A";
            Percentage = "N/A";
            OnPropertyChanged("DisplayGrades");
            GoCalculator = new Command(OpenCalculator);
            GoTranscript = new Command(OpenQUT);
        }

        public Command GoCalculator { get; }
        public Command GoTranscript { get; }

        public async void OpenCalculator()
        {
            string uri = "https://www.newcastle.edu.au/current-students/study-essentials/assessment-and-exams/results/gpa-calculator";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public async void OpenQUT()
        {
            string uri = "https://esoe.qut.edu.au/auth/realms/qut/protocol/openid-connect/auth?response_type=code&client_id=shibboleth-2-idp&redirect_uri=https%3A%2F%2Fidp.qut.edu.au%2Fidp%2Fprofile%2FSAML2%2FPOST%2FSSO?execution%3De3s1%26_eventId_proceed%3D1&state=256114%2Fa44af668-5fba-4976-b19a-2cff8c25a575&scope=openid";
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        void SetUpData()
        {
            Student appStudent = new Student
            {
                Name = "Danny Gold",
                Course = "INO1: Bachelor of Information Systems",
                GPA = "5.7"
            };

            this.course = appStudent.Course;
            this.GPA = appStudent.GPA;


            //List of Units
            StudentUnits = new ObservableCollection<AllUnits>()
            {
                ////////////////////////Current Units/////////////////////////
                new AllUnits
                {
                    UnitCode = "IFB295",
                    UnitName = "Project Management",
                    Grade = "N/A",
                    Percentage = "N/A"
                },

            new AllUnits
                {
                    UnitCode = "IAB330",
                    UnitName = "Mobile Application Development",
                    Grade = "N/A",
                    Percentage = "N/A"
                },

                new AllUnits
                {
                    UnitCode = "CAB303",
                    UnitName = "Networks",
                    Grade = "N/A",
                    Percentage = "N/A"
                },

                new AllUnits
                {
                    UnitCode = "IAB201",
                    UnitName = "Modelling Techniques Info. Systems",
                    Grade = "N/A",
                    Percentage = "N/A"
                },

                ////////////////////Completed Units///////////////////////////

                new AllUnits
                {
                    UnitCode = "CAB302",
                    UnitName = "Software Development",
                    Grade = "5.0",
                    Percentage = "77%"
                },

                new AllUnits
                {
                    UnitCode = "CAB202",
                    UnitName = "Microprocessors",
                    Grade = "6.0",
                    Percentage = "80%"
                },

                new AllUnits
                {
                    UnitCode = "IFB104",
                    UnitName = "Building IT Systems",
                    Grade = "6.0",
                    Percentage = "84%"
                },

                new AllUnits
                {
                    UnitCode = "CAB203",
                    UnitName = "Discrete Structures",
                    Grade = "6.0",
                    Percentage = "75%"
                },

                new AllUnits
                {
                    UnitCode = "IFB102",
                    UnitName = "Fundamentals of IT",
                    Grade = "7.0",
                    Percentage = "99%"
                },

                new AllUnits
                {
                    UnitCode = "IFB103",
                    UnitName = "Designing for IT",
                    Grade = "6.0",
                    Percentage = "79%"
                },

                new AllUnits
                {
                    UnitCode = "IFB130",
                    UnitName = "Database Management",
                    Grade = "4.0",
                    Percentage = "59%"
                },

                new AllUnits
                {
                    UnitCode = "IFB101",
                    UnitName = "Impact of IT",
                    Grade = "5.0",
                    Percentage = "66%"
                },

                new AllUnits
                {
                    UnitCode = "CAB230",
                    UnitName = "Web Computing",
                    Grade = "4.0",
                    Percentage = "50%"
                },

                new AllUnits
                {
                    UnitCode = "CAB330",
                    UnitName = "Data and Web Analytics",
                    Grade = "6.0",
                    Percentage = "79%"
                }
            };

            AssessmentList = new ObservableCollection<Assessment>()
            {
                ///IFB295/////////
                new Assessment
                {
                    Code = "IFB295",
                    AssessmentName = "Quiz 1",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "IFB295",
                    AssessmentName = "Report 1",
                    Mark = "15/20",
                },

                new Assessment
                {
                    Code = "IFB295",
                    AssessmentName = "Quiz 2",
                    Mark = "Ungraded",
                },

                new Assessment
                {
                    Code = "IFB295",
                    AssessmentName = "Report 2",
                    Mark = "Ungraded",
                },

                new Assessment
                {
                    Code = "IFB295",
                    AssessmentName = "Presentation",
                    Mark = "Ungraded",
                },

                new Assessment
                {
                    Code = "IFB295",
                    AssessmentName = "Exam",
                    Mark = "Ungraded",
                },

                ///IAB330////////////
                new Assessment
                {
                    Code = "IAB330",
                    AssessmentName = "Design Report",
                    Mark = "35/40",
                },

                new Assessment
                {
                    Code = "IAB330",
                    AssessmentName = "App MVP",
                    Mark = "Ungraded",
                },

                new Assessment
                {
                    Code = "IAB330",
                    AssessmentName = "Attendance",
                    Mark = "Ungraded",
                },


                //////IAB201/////////
                new Assessment
                {
                    Code = "IAB201",
                    AssessmentName = "Assessment 1",
                    Mark = "30/40",
                },

                new Assessment
                {
                    Code = "IAB201",
                    AssessmentName = "Assessment 2",
                    Mark = "50/50",
                },

                new Assessment
                {
                    Code = "IAB201",
                    AssessmentName = "Exam",
                    Mark = "Ungraded",
                },

                //////CAB303/////////
                new Assessment
                {
                    Code = "CAB303",
                    AssessmentName = "Assessment 1",
                    Mark = "20/25",
                },

                new Assessment
                {
                    Code = "CAB303",
                    AssessmentName = "Assessment 2",
                    Mark = "20/25",
                },

                new Assessment
                {
                    Code = "CAB303",
                    AssessmentName = "Assessment 3",
                    Mark = "Ungraded",
                },

                new Assessment
                {
                    Code = "CAB303",
                    AssessmentName = "Exam",
                    Mark = "Ungraded",
                },

                //////CAB302///////////Previous Subjects 
                new Assessment
                {
                    Code = "CAB302",
                    AssessmentName = "Major Porject",
                    Mark = "45/60",
                },

                new Assessment
                {
                    Code = "CAB302",
                    AssessmentName = "Exam",
                    Mark = "35/40",
                },
                //////CAB202/////////
                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "AMS 1",
                    Mark = "4/5",
                },

                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "AMS 2",
                    Mark = "3/5",
                },

                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "AMS 3",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "AMS 4",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "AMS 5",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "Assessment 1",
                    Mark = "40/40",
                },

                new Assessment
                {
                    Code = "CAB202",
                    AssessmentName = "Assessment 2",
                    Mark = "25/40",
                },

                //////IFB104/////////
                new Assessment
                {
                    Code = "IFB104",
                    AssessmentName = "Quiz",
                    Mark = "20/20",
                },

                new Assessment
                {
                    Code = "IFB104",
                    AssessmentName = "Project 1",
                    Mark = "10/30",
                },

                new Assessment
                {
                    Code = "IFB104",
                    AssessmentName = "Project 2",
                    Mark = "10/20",
                },

                new Assessment
                {
                    Code = "IFB104",
                    AssessmentName = "Exam",
                    Mark = "15/30",
                },

                //////CAB203/////////
                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 1",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 2",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 3",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 4",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 5",
                    Mark = "5/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 6",
                    Mark = "0/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 7",
                    Mark = "0/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 8",
                    Mark = "0/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 9",
                    Mark = "0/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Quiz 10",
                    Mark = "0/5",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Assessment 1",
                    Mark = "18/20",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Assessment 2",
                    Mark = "19/20",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Assessment 3",
                    Mark = "15/20",
                },

                new Assessment
                {
                    Code = "CAB203",
                    AssessmentName = "Exam",
                    Mark = "30/30",
                },
                //////IFB102/////////
                new Assessment
                {
                    Code = "IFB102",
                    AssessmentName = "Report 1",
                    Mark = "29/30",
                },

                new Assessment
                {
                    Code = "IFB102",
                    AssessmentName = "Report 2",
                    Mark = "20/30",
                },

                new Assessment
                {
                    Code = "IFB102",
                    AssessmentName = "Project",
                    Mark = "40/40",
                },
                //////IFB130/////////
                new Assessment
                {
                    Code = "IFB130",
                    AssessmentName = "Modelling 1",
                    Mark = "15/30",
                },

                new Assessment
                {
                    Code = "IFB130",
                    AssessmentName = "Modelling 2",
                    Mark = "15/30",
                },

                new Assessment
                {
                    Code = "IFB130",
                    AssessmentName = "Exam",
                    Mark = "20/40",
                },

                //////IFB103/////////
                new Assessment
                {
                    Code = "IFB103",
                    AssessmentName = "Log Book 1",
                    Mark = "15/30",
                },

                new Assessment
                {
                    Code = "IFB103",
                    AssessmentName = "Log Book 2",
                    Mark = "15/30",
                },

                new Assessment
                {
                    Code = "IFB103",
                    AssessmentName = "Presentation",
                    Mark = "20/40",
                },

                new Assessment
                {
                    Code = "IFB103",
                    AssessmentName = "Quiz",
                    Mark = "20/40",
                },

                //////IFB101/////////
                new Assessment
                {
                    Code = "IFB101",
                    AssessmentName = "Report 1",
                    Mark = "30/30",
                },

                new Assessment
                {
                    Code = "IFB101",
                    AssessmentName = "Report 2",
                    Mark = "35/40",
                },

                new Assessment
                {
                    Code = "IFB101",
                    AssessmentName = "Project",
                    Mark = "10/40",
                },
                //////CAB230//////
                new Assessment
                {
                    Code = "CAB230",
                    AssessmentName = "Project 1",
                    Mark = "20/40",
                },

                new Assessment
                {
                    Code = "CAB230",
                    AssessmentName = "Project 2",
                    Mark = "14/40",
                },

                new Assessment
                {
                    Code = "CAB230",
                    AssessmentName = "AMS",
                    Mark = "18/20",
                },
                //////CAB330/////////
                new Assessment
                {
                    Code = "CAB330",
                    AssessmentName = "Report 1",
                    Mark = "30/40",
                },

                new Assessment
                {
                    Code = "CAB330",
                    AssessmentName = "Project 2",
                    Mark = "30/40",
                },

                new Assessment
                {
                    Code = "CAB330",
                    AssessmentName = "Exam",
                    Mark = "20/20",
                },
            };

            //Copy Data to Display List
            foreach (var assessment in AssessmentList)
            {
                if (assessment.Code == "IFB295")
                {
                    DisplayGrades.Add(assessment);
                }
            }

        }
    }
}