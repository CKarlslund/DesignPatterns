using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using CorneliasBowlinghall.EFDatabase;
using Bowling.Models;
using CorneliasBowlinghall.System;
using CorneliasBowlinghall.Interfaces;
using CorneliasBowlinghall.Tests;
using System.Linq;
using System.Data.Entity;

namespace CorneliasBowlingHall.IntegrationTests
{
    public class CompetitionTests
    {
        private ApplicationDbContext _context;
        private IBowlingRepository _bowlingRepository;

        public CompetitionTests()
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
        public void Can_Save_Competition()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var newGuid = Guid.NewGuid();

            var competition = new Competition()
            {
                Id = newGuid,
                Name = "Hello"
            };

            system.SaveCompetition(competition);

            var foundCompetition = _context.Competitions.FirstOrDefault(x => x.Id == newGuid);

            Assert.Equal(foundCompetition.Id, newGuid);
        }

        [Fact]
        public void Can_Update_Competition()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var competition = _context.Competitions.FirstOrDefault(c => c.Name == "FirstCompetition");

            competition.Name = "ModifiedCompetition";

            system.SaveCompetition(competition);

            var foundCompetition = _context.Competitions.FirstOrDefault(c => c.Id == competition.Id);

            Assert.NotNull(competition);
            Assert.Equal("ModifiedCompetition", foundCompetition.Name);
        }

        [Fact]
        public void Can_Create_Competition()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var id = Guid.NewGuid();
            var startDate = new DateTime(2017,10,04);
            var endDate = new DateTime(2017,11,07);

            system.CreateCompetition("NewCompetition", id, startDate, endDate);

            bool competitionExists = _context.Competitions.ToList().Exists(c => c.Id == id);

            Assert.True(competitionExists);
        }

        [Fact]
        public void Can_Search_Competition()
        {
            var system = new BowlingSystem(_bowlingRepository);

            var competitionToSearchFor = _context.Competitions
                                                .FirstOrDefault(c => c.Name == "FirstCompetition");

            var competitionFoundByName = system.FindCompetitions(competitionToSearchFor.Name).FirstOrDefault();
            var competitionFoundById = system.FindCompetitions(competitionToSearchFor.Id.ToString()).FirstOrDefault();

            Assert.Equal(competitionToSearchFor.Name, competitionFoundByName.Name);
            Assert.Equal(competitionToSearchFor.Id, competitionFoundById.Id);
        }
    }
}
