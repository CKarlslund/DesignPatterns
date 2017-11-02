using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorneliasBowlinghall.Interfaces;
using Bowling.Models;
using AccountabilityLib;
using CorneliasBowlinghall.EFDatabase;
using CorneliasBowlinghall.System;

namespace CorneliasBowlinghall.Tests
{
    class MemoryBowlingRepository : IBowlingRepository
    {
        private List<Competition> _competitions;
        private List<Lane> _lanes;
        private List<Match> _matches;
        private List<Party> _parties;

        public MemoryBowlingRepository()
        {
            _competitions = new List<Competition>();
            _lanes = new List<Lane>();
            _matches = new List<Match>();
            _parties = new List<Party>();
        }

        public void CreateCompetition(string competitionName, Guid competitionId, DateTime startDate, DateTime endDate)
        {
            var competition = new Competition()
            {
                Id = competitionId,
                Name = competitionName,
                Matches = new List<Match>(),
                StartDate = startDate,
                EndDate = endDate
            };

            SaveCompetition(competition);
        }

        public void SaveCompetition(Competition competition)
        {
            var existingCompetition = _competitions.FirstOrDefault(c => c.Id == competition.Id);

            if (existingCompetition != null)
            {
                _competitions.Remove(existingCompetition);
            }
            
            _competitions.Add(competition);
        }

        public List<Competition> FindCompetitions(string searchTerm)
        {
            var results = _competitions.Where(c => 
                                        c.Id.ToString().Equals(searchTerm) ||
                                        c.Name.Equals(searchTerm)
                                        ).ToList();

            return results ?? new List<Competition>();
        }

        public void CreateLane(string name)
        {
            var laneNo = _lanes.Count() + 1;

            var lane = BowlingFactory.CreateLane(name, laneNo);
            _lanes.Add(lane);
        }

        public void CreateParty(string name, string legalId)
        {
            var party = BowlingFactory.CreateParty(name, legalId);
            _parties.Add(party);
        }

        public List<Party> FindParty(string searchTerm)
        {
            var lowerInvariantSearchTerm = searchTerm.ToLowerInvariant();

            return _parties.Where(p =>
                p.Name.ToLowerInvariant().Contains(lowerInvariantSearchTerm) ||
                p.LegalId.Contains(lowerInvariantSearchTerm)).ToList();
        }

        public void CreateMatch(Competition competition, List<Party> players, int laneNumber)
        {
            var lane = _lanes.FirstOrDefault(l => l.LaneNo == laneNumber);

            var matchNo = _matches.Where(m => m.Competition == competition).Count() + 1;

            var match = BowlingFactory.CreateMatch(competition, players, lane, matchNo);
            _matches.Add(match);
            _competitions.FirstOrDefault(c => c.Id == competition.Id).Matches.Add(match);
        }

        public Match FindMatch(Competition competition, int matchNo)
        {
            return _matches.FirstOrDefault(m => m.Competition.Id.Equals(competition.Id) && m.MatchNo == matchNo);
        }

        public void AddScore(Match match, Party player, int score)
        {
            if (match.Series == null || match.Competition == null || match.Lane == null || match.MatchNo == 0)
            {
                throw new Exception("Match is missing data.");
            }

            if (player.Name == null || player.LegalId == null)
            {
                throw new Exception("Player is missing data.");
            }

            var availablePlayerSeries = match.Series.Where(s =>
                s.Player == player &&
                s.Score == null 
                ).ToList();

            if (availablePlayerSeries.Count > 0)
            {
                var seriesToUpdate = availablePlayerSeries.FirstOrDefault();
                seriesToUpdate.Score = score;
            }
            else
            {
                throw new InvalidOperationException("Cannot add more than three scores per player and match");
            }
        }

        public List<Party> GetWinnersOfTheYear(int year)
        {
            var competitions = _competitions.Where(c => c.StartDate.Year == year);

            var playersMatchesWon = new Dictionary<Party, int>();

            foreach (var competition in competitions)
            {
                var matchWinners = competition.Matches.Select(m => m.Winner);

                foreach (var winner in matchWinners)
                {
                    var existingPlayer = playersMatchesWon.FirstOrDefault(p => p.Key == winner).Key;

                    if (existingPlayer == null)
                    {
                        playersMatchesWon.Add(winner, 1);
                    }
                    else
                    {
                        playersMatchesWon[existingPlayer] += 1;
                    }
                }
            }
            var competitionWinners = new List<Party>();

            var matchesWonMax = playersMatchesWon.Values.Max();

            foreach (var playerMatch in playersMatchesWon)
            {
                if (playerMatch.Value == matchesWonMax)
                {
                    competitionWinners.Add(playerMatch.Key);
                }
            }

            return competitionWinners;
        }
    }
}

