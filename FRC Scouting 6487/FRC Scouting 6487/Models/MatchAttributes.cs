using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    public class MatchAttributes
    {
        public enum Strategy
        {
            Defense = 0, Scoring = 1, Combine = 2, Wandering = 3
        }

        public enum ClimbType
        {
            Low = 0, Medium = 1, High = 2, None = 3
        }
    }
}
