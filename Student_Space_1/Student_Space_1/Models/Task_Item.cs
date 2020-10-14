using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class Task_Item
    {
        public string TaskName { get; set; }

        public string Priority { get; set; }

        public DateTime DueDate { get; set; }
        public TimeSpan DueTime { get; set; }

        public string Reminders { get; set; }

        public string Notes { get; set; }

        //Result the TaskName
        public override string ToString()
        {
            return TaskName;
        }

       
    }
}
