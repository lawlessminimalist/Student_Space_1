using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class Announcement
    {
		public string AnnouncementName { get; set; }

		public string AnnouncementInfo { get; set; }

		public override string ToString()
		{
			return AnnouncementName;
		}
	}
}
