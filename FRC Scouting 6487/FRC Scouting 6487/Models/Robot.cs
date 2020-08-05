using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    [Serializable()]
    public class Robot
    {
        public RobotAttributes.Chassis RobotChassis { get; set; }
        public int RobotIntake { get; set; }
        public int RobotScoringFunctions { get; set; }
        public float RobotMass { get; set; }
        public bool IsPassiveLiftable { get; set; }
        public bool IsActiveLiftable { get; set; }
        public bool IsDefensive { get; set; }
        public RobotAttributes.ClimbType RobotClimbType { get; set; }
    }

}
