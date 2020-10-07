using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class ZoomLink
    {
		public string ClassName { get; set; }

		public string ZoomId { get; set; }

		public string Link { get; set; }


		public override string ToString()
		{
			return ClassName;
		}
	}
}
