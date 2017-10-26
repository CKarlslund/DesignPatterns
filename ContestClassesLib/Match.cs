using AccountabilityLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestClassesLib
{
    public class Match
    {
        public int Id { get; set; }

        public int WinnerId { get; set; }
        public Party Winner { get; set; }

        public int Player1Id { get; set; }
        public Party Player1 { get; set; }

        public int Player2Id { get; set; }
        public Party Player2 { get; set; }
        
        public List<Round> Rounds { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
    }
}
