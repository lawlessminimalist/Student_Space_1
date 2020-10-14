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
            SetupData();

            //Get Random Student From List of Students
            var random = new Random();
            int index = random.Next(Students.Count);

            Name = Students[index].Name;
            Picture = Students[index].Picture;
            UserID = Students[index].ID;
        }


        //Create Mock Data
        void SetupData()
        {
            //List of Student's (Store Name, Passwords, Usernames, Images, etc.)
            Students = new ObservableCollection<Student>()
            {
                new Student
                {
                    Name = "Bobby Jones",
                    Picture = Image("Bobby.png"),
                    ID = "n2345678",
                },

                new Student
                {
                    Name = "Frank Peas",
                    Picture = Image("Frank.png"),
                    ID = "n10374648",
                },

                new Student
                {
                    Name = "Mira Yeesus",
                    Picture = Image("Mira.png"),
                    ID = "n33535552",
},

                new Student
                {
                    Name = "Jasmina Torrent",
                    Picture = Image("Jasmina.png"),
                    ID = "n989631111",
                }
            };
        }

        //Helper Function that returns specific format for Image to be Displayed
        public ImageSource Image(string IconSource)
        {
            return ImageSource.FromResource(string.Format("Student_Space_1.PeopleImages.{0}", IconSource));
        }
    }
}