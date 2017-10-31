using AccountabilityLib;
using CorneliasBowlinghall.Interfaces;
using System;
using System.Collections.Generic;
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
            return _bowlingRepository.GetWinnerOfTheYear(year);
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

        public List<Match> FindMatch(Guid competitionId, int matchNo)
        {
            return _bowlingRepository.FindMatch(competitionId, matchNo);
        }

        public void CreateMatch(Competition competition, List<Party> players, int laneid)
        {
            _bowlingRepository.CreateMatch(competition, players, laneid);
        }
    }
}
