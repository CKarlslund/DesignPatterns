using System;
using System.Collections.Generic;
using System.Linq;
using AccountabilityLib;

namespace Bowling.Models
{
    public class Match
    {
        public int Id { get; set; }

        public Party Winner
        {
            get
            {
                List<Party> players = Series.Select(s => s.Player).Distinct().ToList();

                var highScores = new Dictionary<Party, int?>();
                foreach (var player in players)
                {
                    var highScore = Series.Where(s => s.Player == player).Sum(p => p.Score);
                    highScores.Add(player, highScore);
                }

                var winner = highScores.FirstOrDefault(x => x.Value == highScores.Values.Max()).Key;

                return winner;
            }
        }    
        
        public List<Series> Series { get; set; }

        public Guid CompetitionId { get; set; }
        public Competition Competition { get; set; }

        public int LaneId { get; set; }
        public Lane Lane { get; set; }

        public int MatchNo { get; set; }
    }
}
