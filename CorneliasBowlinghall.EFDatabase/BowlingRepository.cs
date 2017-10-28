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

        public void CreateCompetition(string competitionName, Guid competitionId)
        {
            var competition = BowlingFactory.CreateCompetition(competitionId, competitionName);

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
        }

        public Match FindMatch(Guid competitionId, int matchNo)
        {
            return _context.Matches.FirstOrDefault(m => m.Competition.Id.Equals(competitionId) && m.MatchNo == matchNo);
        }

        public void CreateSeries(int points, int seqNumber, Party Player)
        {
            //TODO ADD
            throw new NotImplementedException();
        }

        public void CreateLane(string name)
        {
            //TODO ADD
            throw new NotImplementedException();
        }

        public void CreateParty(string name, string legalId)
        {
            //TODO ADD
            throw new NotImplementedException();
        }

        public void FindParty(string searchTerm)
        {
            //TODO ADD
            throw new NotImplementedException();
        }

        public void AddScore(Match match, Party player, int score)
        {
            //var matchToUpdate = _context.Matches.FirstOrDefault(m => m.Id == match.Id);

            var availablePlayerSeries = _context.Series.Where(s => 
                                                        s.Player == player && 
                                                        s.Score == null &&
                                                        s.MatchId == match.Id).ToList();

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
    }
}
