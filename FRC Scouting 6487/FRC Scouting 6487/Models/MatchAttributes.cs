using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    public class MatchAttributes
    {
        public enum Strategy
        {
            Wandering = 0, Scoring = 1, Defense = 2, Combine = 3
        }

        public enum ClimbType
        {
            None = 0, Climb1 = 1, Climb2 = 2, Climb3 = 3
        }
    }
}
