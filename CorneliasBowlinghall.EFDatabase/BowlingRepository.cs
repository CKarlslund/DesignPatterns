using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;
using Bowling.Models;
using CorneliasBowlinghall;
using CorneliasBowlinghall.Interfaces;
using CorneliasBowlinghall.System;

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

            _context.Add(competition);
            _context.SaveChanges();
        }

        public void SaveCompetition(Competition competition)
        {
            _context.Add(competition);
            _context.SaveChanges();
        }

        public List<Competition> FindCompetitions(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void CreateSeries(int points, int seqNumber, Party Player)
        {
            throw new NotImplementedException();
        }

        public void CreateLane(string name)
        {
            throw new NotImplementedException();
        }

        public void CreateParty(string name, string legalId)
        {
            throw new NotImplementedException();
        }

        public void FindParty(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
