using System;
using System.Collections.Generic;
using System.Text;
using CorneliasBowlinghall.Interfaces;
using Bowling.Models;
using AccountabilityLib;

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
            //TODO add
        }

        public void SaveCompetition(Competition competition)
        {
            //TODO add
        }

        public List<Competition> FindCompetitions(string searchTerm)
        {
            //TODO add
            return new List<Competition>();
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
    }
}

