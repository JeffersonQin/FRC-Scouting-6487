using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    public class DisplayString
    {
        public string value { get; set; }

        public DisplayString(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            if (this.value.Equals("")) return "Unkown Value";
            return this.value;
        }
    }
}
