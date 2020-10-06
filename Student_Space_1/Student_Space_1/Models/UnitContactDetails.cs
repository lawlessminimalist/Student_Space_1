using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Student_Space_1.Models
{
    public class UnitContactDetails
    {
		public string Name { get; set; }

		public string Position { get; set; }

		public string Email { get; set; }

		public string OfficeLocation { get; set; }

		public string Code { get; set; }

		//Image of Person
		public Image Contact_Picture { get; set; }

		//Get Contact Code
		public override string ToString()
		{
			return Code;
		}

	}
}
