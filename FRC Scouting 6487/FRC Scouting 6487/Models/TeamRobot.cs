using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    class TeamRobot
    {
        public int TeamNumber { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }
        public int RobotChassis { get; set; }
        public int RobotIntake { get; set; }
        public int RobotScoringFunctions { get; set; }
        public float RobotMass { get; set; }
        public bool IsPassiveLiftable { get; set; }
        public bool IsActiveLiftable { get; set; }
        public bool IsDefensive { get; set; }
        public int RobotClimbType { get; set; }
        public List<Match> Matches { get; set; }
    }
}
