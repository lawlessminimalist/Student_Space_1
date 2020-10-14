using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Space_1.Models
{
    public class Colour
    {
        public string ColourName { get; set; }

        public string hexValue { get; set; }

        public override string ToString()
        {
            return ColourName;
        }

    }
}
