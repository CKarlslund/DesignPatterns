using System;
using System.Collections.Generic;
using System.Text;
using AccountabilityLib;

namespace CorneliasBowlinghallLib
{
    public class BowlingSystem
    {
        private IBowlingRepository _bowlingRepository;
        private IPartyRepository _partyRepository;

        public BowlingSystem(IBowlingRepository bowlingRepository, IPartyRepository partyRepository)
        {
            _bowlingRepository = bowlingRepository;
            _partyRepository = partyRepository;
        }


        public Party GetWinnerOfTheYear(int year)
        {
            //TODO Winner
            //get all matches via repository
            //calculate
            //return party
        }

        public void CreateParty()
        {
            //TODO CreateParty
        }

        public Party FindParty(string searchTerm)
        {
            //TODO findParty
        }



    }
}
