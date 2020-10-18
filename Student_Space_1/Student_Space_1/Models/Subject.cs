using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class Subject
    {
		public string SubjectName { get; set; }

		public string SubjectID { get; set; }

		public override string ToString()
		{
			return SubjectName;
		}

	}
}
