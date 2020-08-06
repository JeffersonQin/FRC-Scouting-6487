using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    public class RobotAttributes
    {
        public enum Chassis
        {
            Other = 0, Chassis1 = 1, Chassis2 = 2, Chassis3 = 3
        }

        public enum ClimbType
        {
            None = 0, Climb1 = 1, Climb2 = 2, Climb3 = 3
        }

        public class InTakeFunctions
        {
            public int InTakeSource01 = 1;
            public int InTakeSource02 = 2;
            public int InTakeSource03 = 4;
            public int InTakeSource04 = 8;
            public int InTakeSource05 = 16;
        }

        public class ScoringFunctions
        {
            public int ScoringPlace01 = 1;
            public int ScoringPlace02 = 2;
            public int ScoringPlace03 = 4;
            public int ScoringPlace04 = 8;
            public int ScoringPlace05 = 16;
        }
    }
}
