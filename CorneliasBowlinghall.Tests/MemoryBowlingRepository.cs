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

        public void CreateMatch(Competition competition, List<Party> players, int laneId)
        {
            var lane = _lanes.FirstOrDefault(l => l.Id == laneId);

            var matchNo = competition.Matches.Count + 1;

            var match = BowlingFactory.CreateMatch(competition, players, lane, matchNo);
            _matches.Add(match);
        }

        public List<Match> FindMatch(Guid competitionId, int matchNo)
        {
            return _matches.Where(m => m.Competition.Id.Equals(competitionId) && m.MatchNo == matchNo).ToList();
        }

        public void AddScore(Match match, Party player, int score)
        {
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

        public Party GetWinnerOfTheYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}

