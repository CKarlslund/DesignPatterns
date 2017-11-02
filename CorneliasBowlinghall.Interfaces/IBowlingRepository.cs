using System;
using System.Collections.Generic;
using AccountabilityLib;
using Bowling.Models;

namespace CorneliasBowlinghall.Interfaces
{
    public interface IBowlingRepository
    {
        void CreateCompetition(string competitionName, Guid competitionId, DateTime competition1StartDate, DateTime competition1EndDate);

        void SaveCompetition(Competition competition);

        List<Competition> FindCompetitions(string searchTerm);

        void CreateMatch(Competition competition, List<Party> players, int laneNumber);

        Match FindMatch(Competition competition, int matchNo);

        void CreateLane(string name);

        void CreateParty(string name, string legalId);

        List<Party> FindParty(string searchTerm);

        void AddScore(Match match, Party player, int score);

        List<Party> GetWinnersOfTheYear(int year);
    }
}
