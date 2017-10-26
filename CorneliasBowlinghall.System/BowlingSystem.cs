using AccountabilityLib;
using CorneliasBowlinghall.Interfaces;
using System;
using Bowling.Models;

namespace CorneliasBowlinghall.System
{
    public class BowlingSystem
    {
        private IBowlingRepository _bowlingRepository;

        public BowlingSystem(IBowlingRepository bowlingRepository)
        {
            _bowlingRepository = bowlingRepository;
        }


        public Party GetWinnerOfTheYear(int year)
        {
            //TODO Winner
            //get all matches via repository
            //calculate
            //return party
            return new Party();
        }

        public void CreateParty()
        {
            //TODO CreateParty
        }

        public Party FindParty(string searchTerm)
        {
            //TODO findParty
            return new Party();
        }

        public Competition FindCompetition(string v)
        {
            throw new NotImplementedException();
        }

        public void SaveCompetition(object competition)
        {
            throw new NotImplementedException();
        }

        public void CreateCompetition(string v, Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
