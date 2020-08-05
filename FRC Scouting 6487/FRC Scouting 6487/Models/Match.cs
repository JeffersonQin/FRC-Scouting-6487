using System;
using System.Collections.Generic;
using System.Text;

namespace FRC_Scouting_6487.Models
{
    [Serializable()]
    public class Match
    {
        public int MatchIndex { get; set; }
        public int ScoringItemCount01 { get; set; }
        public int ScoringItemCount02 { get; set; }
        public int ScoringItemCount03 { get; set; }
        public int ScoringItemCount04 { get; set; }
        public int ScoringItemCount05 { get; set; }
        public MatchAttributes.Strategy MatchStrategy { get; set; }
        public MatchAttributes.ClimbType MatchClimbType { get; set; }
        public bool IsPassiveLifted { get; set; }
        public bool IsActiveLifted { get; set; }
        public bool WhetherDefensed { get; set; }
    }

}
