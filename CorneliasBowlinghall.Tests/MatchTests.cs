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
        public void Can_Add_Score()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

            var player1 = system.FindParty("Agneta").FirstOrDefault();
            var player2 = system.FindParty("Ahmed").FirstOrDefault();

            var players = new List<Party> { player1, player2 };

            var match = system.FindMatch(competition, 1);

            system.AddScore(match, player1, 50);

        }

        [Fact]
        public void Match_Has_Correct_Winner()
        {
            var system = new BowlingSystem(_bowlingRepository);
                
            var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

            var player1 = system.FindParty("winner2017").FirstOrDefault();
            var player2 = system.FindParty("winner2018").FirstOrDefault();

            var players = new List<Party>{player1, player2};

            system.CreateMatch(competition, players, 2);
            var match = system.FindMatch(competition, 2);

            system.AddScore(match, player1, 100);
            system.AddScore(match, player1, 100);
            system.AddScore(match, player1, 100);

            system.AddScore(match, player2, 15);
            system.AddScore(match, player2, 15);
            system.AddScore(match, player2, 15);
           
            var matchWinner = match.Winner;

            Assert.Equal(player1, matchWinner);
        }

        [Fact]
        public void Winner_Of_The_Year_Is_Correct()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var sut1 = system.GetWinnersOfTheYear(2018).FirstOrDefault();
            var sut2 = system.GetWinnersOfTheYear(2017).FirstOrDefault();

            Assert.Equal("winner2018", sut1.Name);
            Assert.Equal("winner2017", sut2.Name);
        }

        [Fact]
        public void Cannot_Add_Score_If_Match_Is_Missing_Data()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var match = new Match();

            var party = system.FindParty("winner2017").FirstOrDefault();

            Assert.Throws<Exception>(() => system.AddScore(match, party, 10));
        }

        [Fact]
        public void Cannot_Add_Score_If_Party_Is_Missing_Data()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

            var match = system.FindMatch(competition, 1);

            var party = new Party();

            Assert.Throws<Exception>(() => system.AddScore(match, party, 10));
        }
    }
}
