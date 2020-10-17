using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Student_Space_1.Models
{
    public class Student
    {
        public string Name { get; set; }

        public string Course { get; set; }

        public string GPA { get; set; }

        //Image of Person
        public ImageSource Picture { get; set; }

        public string ID { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return Name + ID;
        }
    }
}
