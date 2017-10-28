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
            //TODO Winner
            //get all matches via repository
            //calculate
            //return party
            return new Party();
        }

        public List<Party> GetMatchWinners()
        {
            //TODO add
            return new List<Party>();
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

        public void CreateCompetition(string competitionName, Guid competitionId)
        {
            _bowlingRepository.CreateCompetition(competitionName, competitionId);
        }

        public Match FindMatch(Guid competitionId, int matchNo)
        {
            return _bowlingRepository.FindMatch(competitionId, matchNo);
        }

        public void CreateMatch(Competition competition, List<Party> players, int laneid)
        {
            _bowlingRepository.CreateMatch(competition, players, laneid);
        }
    }
}
