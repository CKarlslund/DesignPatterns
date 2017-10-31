using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;
using Bowling.Models;

namespace CorneliasBowlinghall.System
{
    public class BowlingFactory
    {
        public static Competition CreateCompetition(Guid competitionId, 
                                                    string competitionName, 
                                                    DateTime startDate, 
                                                    DateTime endDate)
        {
            return new Competition()
            {
                Id = competitionId,
                Name = competitionName,
                Matches = new List<Match>(),
                StartDate = startDate,
                EndDate = endDate
            };
        }

        public static Match CreateMatch(Competition competition, List<Party> matchPlayers, Lane lane, int matchNo)
        {
            var series = new List<Series>();

            foreach (var player in matchPlayers)
            {
                for (int i = 1; i < 4; i++)
                {
                    var playerSeries = new Series()
                    {
                        SeqNo = i,
                        Player = player,
                    };

                    series.Add(playerSeries);
                }
            }

            return new Match()
            {
                Competition = competition,
                Series = series,
                Lane = lane,
                MatchNo = matchNo
            };
        }

        public static Lane CreateLane(string name, int lanteNo)
        {
            return new Lane()
            {
                Name = name,
                LaneNo = lanteNo
            };
        }

        public static Party CreateParty(string name, string legalId)
        {
            return new Party()
            {
                Name = name,
                LegalId = legalId,
            };
        }
    }
}
