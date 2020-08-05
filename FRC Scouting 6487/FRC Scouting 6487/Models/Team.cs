using FRC_Scouting_6487.Lib;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    public class Team
    {
        [PrimaryKey]
        public int TeamNumber { get; set; }
        public string TeamName { get; set; }
        public string Country { get; set; }
        [Ignore]
        public Robot TeamRobot
        {
            get { return this.TeamRobot; }
            set
            {
                this.TeamRobot = value;
                this.TeamRobotData = JSONHelper.ObjectToJSON(value);
            }
        }
        [Ignore]
        public List<Match> Matches
        {
            get { return this.Matches; }
            set
            {
                this.Matches = value;
                this.MatchesData = JSONHelper.ObjectToJSON(value);
            }
        }
        public string TeamRobotData
        {
            get { return this.TeamRobotData; }
            set
            {
                this.TeamRobotData = value;
                this.TeamRobot = JSONHelper.JSONToObject<Robot>(value);
            }
        }
        public string MatchesData
        {
            get { return this.MatchesData; }
            set
            {
                this.MatchesData = value;
                this.Matches = JSONHelper.JSONToObject<List<Match>>(value);
            }
        }
    }
}
