using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class SubjectField
    {
		public string SubjectFieldName { get; set; }

		public override string ToString()
		{
			return SubjectFieldName;
		}
	}
}
