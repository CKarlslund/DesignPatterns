using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;
using Bowling.Models;
using CorneliasBowlinghall;
using CorneliasBowlinghall.Interfaces;
using CorneliasBowlinghall.System;
using System.Linq;
using System.Data.Entity.Migrations;


namespace CorneliasBowlinghall.EFDatabase
{
    public class BowlingRepository : IBowlingRepository
    {
        private ApplicationDbContext _context;

        public BowlingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateCompetition(string competitionName, Guid competitionId, DateTime startDate, DateTime endDate)
        {
            var competition = BowlingFactory.CreateCompetition(competitionId, competitionName, startDate, endDate);

            _context.Competitions.Add(competition);
            _context.SaveChanges();
        }

        public void SaveCompetition(Competition competition)
        {
            var existingCompetition = _context.Competitions.FirstOrDefault(c => c.Id == competition.Id);

            if (existingCompetition == null)
            {
                _context.Add(competition);
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(existingCompetition).CurrentValues.SetValues(competition);
                _context.SaveChanges();
            }
        }

        public List<Competition> FindCompetitions(string searchTerm)
        {
            var results = _context.Competitions.Where(c =>
                c.Id.ToString().Equals(searchTerm) ||
                c.Name.Equals(searchTerm)
            ).ToList();

            return results ?? new List<Competition>();
        }

        public void CreateMatch(Competition competition, List<Party> players, int laneId)
        {
            var lane = _context.Lanes.FirstOrDefault(l => l.Id == laneId);

            var matchNo = competition.Matches.Count + 1;
            
            var match = BowlingFactory.CreateMatch(competition, players, lane, matchNo);
            _context.Add(match);
            _context.SaveChanges();
        }

        public List<Match> FindMatch(Guid competitionId, int matchNo)
        {
            return _context.Matches.Where(m => m.Competition.Id.Equals(competitionId) && m.MatchNo == matchNo).ToList();           
        }

        public void CreateLane(string name)
        {
            var laneNo = _context.Lanes.Count() + 1;

            var lane = BowlingFactory.CreateLane(name, laneNo);
            _context.Add(lane);
            _context.SaveChanges();
        }

        public void CreateParty(string name, string legalId)
        {
            var party = BowlingFactory.CreateParty(name, legalId);
            _context.Add(party);
            _context.SaveChanges();
        }

        public List<Party> FindParty(string searchTerm)
        {
            var lowerInvariantSearchTerm = searchTerm.ToLowerInvariant();

            return _context.Parties.Where(p => 
                                                p.Name.ToLowerInvariant().Contains(lowerInvariantSearchTerm) ||
                                                p.LegalId.Contains(lowerInvariantSearchTerm)).ToList();
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

                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Cannot add more than three scores per player and match");
            }
        }

        public Party GetWinnerOfTheYear(int year)
        {
            var competitions = _context.Competitions.Where(c => c.StartDate.Year == year);

            var players = new Dictionary<Party, int>();

            foreach (var competition in competitions)
            {
                var winners = competition.Matches.Select(m => m.Winner);
               
                foreach (var winner in winners)
                {
                    var existingPlayer = players.FirstOrDefault(p => p.Key == winner).Key;

                    if (existingPlayer == null)
                    {
                        players.Add(winner,1);
                    }
                    else
                    {
                        players[existingPlayer] += 1;
                    }
                }
            }
            return players.Keys.Max();
        }
    }
}
