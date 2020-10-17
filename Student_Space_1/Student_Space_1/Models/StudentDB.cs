using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Student_Space_1.Models
{
    class StudentDB
    {
        //Using Singleton Pattern
        private StudentDB()
        {
            //Initalize Collection
            _Studentlist = new ObservableCollection<Student>();

            try
            {
                Setup();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Cannot get Data!" + ex);
            }
        }

        public static StudentDB Instance { get; } = new StudentDB();

        private ObservableCollection<Student> _Studentlist;
        public ObservableCollection<Student> Studentlist
        {
            get { return _Studentlist; }
            set { _Studentlist = value; }
        }

        //Set up some Mock Data
        public void Setup()
        {
            Student new_student1 = new Student
            {
                Name = "Bobby Jones",
                Picture = Image("Bobby.png"),
                ID = "n12345",
                Password = "changeme",
            };

            Student new_student2 = new Student
            {
                Name = "Frank Peas",
                Picture = Image("Frank.png"),
                ID = "n678910",
                Password = "admin1234",
            };

            Student new_student3 = new Student
            {
                Name = "Mira Yeesus",
                Picture = Image("Mira.png"),
                ID = "n101010",
                Password = "123456",
            };

            Student new_student4 = new Student
            {
                Name = "Jasmina Torrent",
                Picture = Image("Jasmina.png"),
                ID = "n999888",
                Password = "password1",
            };

            _Studentlist.Add(new_student1);
            _Studentlist.Add(new_student2);
            _Studentlist.Add(new_student3);
            _Studentlist.Add(new_student4);
        }

        //Helper Function that returns specific format for Image to be Displayed
        public ImageSource Image(string IconSource)
        {
            return ImageSource.FromResource(string.Format("Student_Space_1.PeopleImages.{0}", IconSource));
        }
    }
}
