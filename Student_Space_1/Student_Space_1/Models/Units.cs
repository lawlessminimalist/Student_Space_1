using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class Units
    {
		public string UnitCode { get; set; }

		public string UnitName { get; set; }

		public string Grade { get; set; }

		//Not Sure what this is??
		public override string ToString()
		{
			return UnitCode + ":   " + UnitName;
		}

	}
}
