using AccountabilityLib;
using Bowling.Models;
using CorneliasBowlinghall.EFDatabase;
using CorneliasBowlinghall.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorneliasBowlinghall.Tests
{
    public static class CompetitionFaker
    {
        public static List<Competition> Competitions { get; set; }

        public static void GenerateFakeCompetitions(IBowlingRepository bowlingRepository)
        {
            //TODO add competitions

            var competition1Id = Guid.NewGuid();
            bowlingRepository.CreateCompetition("FirstCompetition", competition1Id);

            var matchDate = new DateTime(2017,12,24,05,00,00);
            var matchPlayers = new List<Party>();

            //bowlingRepository.CreateMatch(matchPlayers, 1);

            var competition2Id = Guid.NewGuid();
            bowlingRepository.CreateCompetition("SecondCompetition", competition2Id);

        }
    }

    
}
