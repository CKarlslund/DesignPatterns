using AccountabilityLib;
using Bowling.Models;
using CorneliasBowlinghall.Interfaces;
using CorneliasBowlinghall.System;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace CorneliasBowlinghall.Tests
{
    public class MatchTests
    {
        private IBowlingRepository _bowlingRepository;


        public MatchTests()
        {
            _bowlingRepository = new MemoryBowlingRepository();

            CompetitionFaker.GenerateFakeCompetitions(_bowlingRepository);
        }

        [Fact]
        public void Match_Has_Correct_Winner()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var player1 = new Party {Name = "Agneta",};
            var player2 = new Party {Name = "Ahmed",};

            var players = new List<Party>() {player1, player2};

            var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

            system.CreateMatch(competition, players, 1);

            var match = system.FindMatch(competition.Id, 1);

            system.AddScore(match, player1, 15);
            system.AddScore(match, player1, 15);
            system.AddScore(match, player1, 15);

            system.AddScore(match, player2, 15);
            system.AddScore(match, player2, 16);
            system.AddScore(match, player2, 15);

            var thing = "Stop here";

        }
    }
}
