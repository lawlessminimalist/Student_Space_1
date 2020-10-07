using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class AllUnits
    {
		public string UnitCode { get; set; }

		public string UnitName { get; set; }

		public string Grade { get; set; } //GPA Representation of Unit

		public string Percentage { get; set; } //Percentage Representation of Unit Grade

		//Not Sure what this is??
		public override string ToString()
		{
			return UnitCode + "   " + UnitName + "   " + Grade;
		}
	}
}
