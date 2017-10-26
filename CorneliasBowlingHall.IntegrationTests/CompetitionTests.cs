using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using CorneliasBowlinghall.EFDatabase;
using Bowling.Models;
using CorneliasBowlinghall.System;
using CorneliasBowlinghall.Interfaces;
using CorneliasBowlinghall.Tests;

namespace CorneliasBowlingHall.IntegrationTests
{
    public class CompetitionTests
    {
        private ApplicationDbContext _context;
        private IBowlingRepository _bowlingRepository;

        public CompetitionTests()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CorneliasBowlinghall;Trusted_Connection=True;");
            _context = new ApplicationDbContext(optionBuilder.Options);

            var competitions = CompetitionFaker.GenerateFakeCompetitions(_bowlingRepository);
            _context.AddRa

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _bowlingRepository = new BowlingRepository(_context);
        }

        [Fact]
        public void Can_Save_Competition()
        {
            var system = new BowlingSystem(_bowlingRepository);

            system.CreateCompetition("Hello", Guid.NewGuid());

            var competition = system.FindCompetition("hello");

            var match = new Match() { };

            competition.Matches.Add(match);

            system.SaveCompetition(competition);



            Assert.Equal("Hello", "Hello");
        }

        [Fact]
        public void Can_Create_Competition()
        {
            
        }

        [Fact]
        public void Can_Search_Competition()
        {
            
        }
    }
}
