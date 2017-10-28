using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorneliasBowlinghall.Interfaces;
using Bowling.Models;
using AccountabilityLib;
using CorneliasBowlinghall.EFDatabase;

namespace CorneliasBowlinghall.Tests
{
    class MemoryBowlingRepository : IBowlingRepository
    {
        private List<Competition> _competitions;

        public MemoryBowlingRepository()
        {
            _competitions = new List<Competition>();
        }

        public void CreateCompetition(string competitionName, Guid competitionId)
        {
            var competition = new Competition()
            {
                Id = competitionId,
                Name = competitionName
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
            //TODO add
            var results = _competitions.Where(c => 
                                        c.Id.ToString().Equals(searchTerm) ||
                                        c.Name.Equals(searchTerm)
                                        ).ToList();

            return results ?? new List<Competition>();
        }

        public void CreateLane(string name)
        {
            //TODO add

        }

        public void CreateParty(string name, string legalId)
        {
            //TODO add
        }

        public void FindParty(string searchTerm)
        {
            //TODO add}
        }

        public void CreateSeries(int points, int seqNumber, Party Player)
        {
            //TODO add
        }

        public void CreateMatch()
        {
            //TODO add
            throw new NotImplementedException();
        }

        public void CreateMatch(Competition competition, List<Party> players, int laneId)
        {
            throw new NotImplementedException();
        }

        public Match FindMatch(Guid competitionId, int matchNo)
        {
            throw new NotImplementedException();
        }

        public void AddScore(Match match, Party player, int score)
        {
            throw new NotImplementedException();
        }
    }
}

