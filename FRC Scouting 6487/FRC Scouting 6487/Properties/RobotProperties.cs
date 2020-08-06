using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Properties
{
    public static class RobotProperties
    {
        public static List<String> ClimbTypes = new List<String>()
        {
            "None",
            "Low",
            "Medium",
            "High"
        };
        public static List<String> ChassisTypes = new List<String>()
        { 
            "Other",
            "Tank",
            "Swerve",
            "Macanum"
        };
        public static List<String> InTakeTypes = new List<String>()
        {
            "Source 01",
            "Source 02",
            "Source 03",
            "Source 04",
            "Source 05"
        };
        public static List<String> ScoringTypes = new List<String>()
        {
            "Place 01",
            "Place 02",
            "Place 03",
            "Place 04",
            "Place 05"
        };
    }
}
