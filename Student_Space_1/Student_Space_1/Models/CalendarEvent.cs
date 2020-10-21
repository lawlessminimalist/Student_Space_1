using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Student_Space_1.Models
{
    class CalendarEvent
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public string Location { get; set; }
        public Color EventColor { get; set; }

    }
}
