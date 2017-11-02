using AccountabilityLib;
using CorneliasBowlinghall.Interfaces;
using System;
using System.Collections.Generic;
using Bowling.Models;

namespace CorneliasBowlinghall.System
{
    public class BowlingSystem
    {
        private static IBowlingRepository _bowlingRepository;

        private static BowlingSystem _instance;

        protected BowlingSystem(IBowlingRepository bowlingRepository)
        {
            _bowlingRepository = bowlingRepository;
        }

        public static BowlingSystem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BowlingSystem(_bowlingRepository);
                return _instance;
            }
        }

        public List<Party> GetWinnersOfTheYear(int year)
        {
            return _bowlingRepository.GetWinnersOfTheYear(year);
        }

        public void CreateParty(string name, string legalId)
        {
            _bowlingRepository.CreateParty(name, legalId);
        }

        public List<Party> FindParty(string searchTerm)
        {
            return _bowlingRepository.FindParty(searchTerm);
        }

        public List<Competition> FindCompetitions(string searchTerm)
        {
            return _bowlingRepository.FindCompetitions(searchTerm);
        }

        public void AddScore(Match match, Party player, int score)
        {
            _bowlingRepository.AddScore(match, player, score);
        }

        public void SaveCompetition(Competition competition)
        {
            _bowlingRepository.SaveCompetition(competition);
        }

        public void CreateCompetition(string competitionName, Guid competitionId, DateTime startDate, DateTime endDate)
        {
            _bowlingRepository.CreateCompetition(competitionName, competitionId, startDate, endDate);
        }

        public Match FindMatch(Competition competition, int matchNo)
        {
            return _bowlingRepository.FindMatch(competition, matchNo);
        }

        public void CreateMatch(Competition competition, List<Party> players, int laneid)
        {
            _bowlingRepository.CreateMatch(competition, players, laneid);
        }
    }
}
