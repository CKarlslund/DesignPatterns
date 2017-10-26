using System;
using System.Collections.Generic;
using AccountabilityLib;
using Bowling.Models;

namespace CorneliasBowlinghall.Interfaces
{
    public interface IBowlingRepository
    {
        void CreateCompetition(string competitionName, Guid competitionId);

        void SaveCompetition(Competition competition);

        List<Competition> FindCompetitions(string searchTerm);

        void CreateSeries(int points, int seqNumber, Party Player);

        void CreateLane(string name);

        void CreateParty(string name, string legalId);

        void FindParty(string searchTerm);
    }
}
