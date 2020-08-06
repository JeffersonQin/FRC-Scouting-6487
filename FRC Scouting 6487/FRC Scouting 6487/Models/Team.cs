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

        private bool setFlag = false;

        [Ignore]
        private Robot teamRobot { get; set; }

        [Ignore]
        public Robot TeamRobot
        {
            get { return this.teamRobot; }
            set
            {
                if (setFlag) { setFlag = false; return; }
                setFlag = true;
                this.teamRobot = value;
                this.TeamRobotData = JSONHelper.ObjectToJSON(value);
            }
        }
        [Ignore]
        private List<Match> matches { get; set; }

        [Ignore]
        public List<Match> Matches
        {
            get { return this.matches; }
            set
            {
                if (setFlag) { setFlag = false; return; }
                setFlag = true;
                this.matches = value;
                this.MatchesData = JSONHelper.ObjectToJSON(value);
            }
        }

        [Ignore]
        private string teamRobotData { get; set; }
        public string TeamRobotData
        {
            get { return this.teamRobotData; }
            set
            {
                if (setFlag) { setFlag = false; return; }
                setFlag = true;
                this.teamRobotData = value;
                this.TeamRobot = JSONHelper.JSONToObject<Robot>(value);
            }
        }

        [Ignore]
        private string matchesData { get; set; }
        public string MatchesData
        {
            get { return this.matchesData; }
            set
            {
                if (setFlag) { setFlag = false; return; }
                setFlag = true;
                this.matchesData = value;
                this.Matches = JSONHelper.JSONToObject<List<Match>>(value);
            }
        }
    }
}
