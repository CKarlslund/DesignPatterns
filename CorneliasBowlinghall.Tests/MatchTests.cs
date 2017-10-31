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

        //[Fact]
        //public void Can_Add_Score()
        //{
        //    var system = new BowlingSystem(_bowlingRepository);

        //    var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

        //    var player1 = system.FindParty("Agneta").FirstOrDefault();
        //    var player2 = system.FindParty("Ahmed").FirstOrDefault();

        //    var players = new List<Party> { player1, player2 };

        //    system.CreateMatch(competition, players, 1);

            


        //}

        [Fact]
        public void Match_Has_Correct_Winner()
        {
            var system = new BowlingSystem(_bowlingRepository);
                
            var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

            var player1 = system.FindParty("Agneta").FirstOrDefault();
            var player2 = system.FindParty("Ahmed").FirstOrDefault();

            var players = new List<Party>{player1, player2};

            system.CreateMatch(competition, players, 1);

            var match = system.FindMatch(competition.Id, 1).FirstOrDefault();

            system.AddScore(match, player1, 15);
            system.AddScore(match, player1, 15);
            system.AddScore(match, player1, 15);

            system.AddScore(match, player2, 15);
            system.AddScore(match, player2, 16);
            system.AddScore(match, player2, 15);

            var matchWinner = match.Winner;

            Assert.Equal(player2, matchWinner);
        }

        [Fact]
        public void Winner_Of_The_Year_Is_Correct()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var sut = system.GetWinnerOfTheYear(2018);


        }
    }
}
