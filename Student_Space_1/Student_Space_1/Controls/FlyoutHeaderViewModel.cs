using Student_Space;
using Student_Space_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Student_Space_1.Controls
{
    class FlyoutHeaderViewModel
    {

        public ObservableCollection<Student> Students = new ObservableCollection<Student>();

        public string Name { get; set; }
        public ImageSource Picture { get; set; }

        public string UserID { get; set; }
        public FlyoutHeaderViewModel()
        {

            //Access Shared Observable Collection (List of Students)
            StudentListDB = StudentDB.Instance;

            //Get Object and Assign Variables
            foreach(Student user in ListStudent)
            {
                if (App.User.Equals(user.ID))
                {
                    //Found the logged in User
                    Name = user.Name;
                    UserID = user.ID;
                    Picture = user.Picture;
                    break;
                }
                else
                {
                    Console.Write("Error!! Cannot find user");
                }

            }

        }


        //Helper Function that returns specific format for Image to be Displayed
        public ImageSource Image(string IconSource)
        {
            return ImageSource.FromResource(string.Format("Student_Space_1.PeopleImages.{0}", IconSource));
        }

        //Access List of Users
        //Handle Data
        private StudentDB StudentListDB;

        private ObservableCollection<Student> myVar;
        public ObservableCollection<Student> ListStudent //Bind this to the View
        {
            get { return StudentListDB.Studentlist; }
            set
            {
                myVar = value;
                //OnPropertyChanged();
            }

        }

    }
}