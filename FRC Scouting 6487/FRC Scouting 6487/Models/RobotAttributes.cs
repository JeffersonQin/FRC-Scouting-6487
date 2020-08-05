using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    public class RobotAttributes
    {
        public enum Chassis
        {
            Tank = 0, Swerve = 1, Macanum = 2, Other = 3
        }

        public enum ClimbType
        {
            Low = 0, Medium = 1, High = 2, None = 3
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
