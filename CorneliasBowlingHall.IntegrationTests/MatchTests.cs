using CorneliasBowlinghall.EFDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using CorneliasBowlinghall.Tests;
using Microsoft.EntityFrameworkCore;
using Xunit;
using CorneliasBowlinghall.System;
using AccountabilityLib;
using System.Linq;
using CorneliasBowlinghall.Interfaces;

namespace CorneliasBowlingHall.IntegrationTests
{
    public class MatchTests
    {
        private ApplicationDbContext _context;
        private IBowlingRepository _bowlingRepository;

        public MatchTests()
        {
            var randomDatabaseName = Guid.NewGuid();

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database={randomDatabaseName};Trusted_Connection=True;");
            _context = new ApplicationDbContext(optionBuilder.Options);

            _bowlingRepository = new BowlingRepository(_context);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            CompetitionFaker.GenerateFakeCompetitions(_bowlingRepository);
        }

        [Fact]
        public void Match_Has_Correct_Winner()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var competition = system.FindCompetitions("FirstCompetition").FirstOrDefault();

            var player1 = system.FindParty("winner2017").FirstOrDefault();
            var player2 = system.FindParty("winner2018").FirstOrDefault();

            var players = new List<Party> { player1, player2 };

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
    }
}
