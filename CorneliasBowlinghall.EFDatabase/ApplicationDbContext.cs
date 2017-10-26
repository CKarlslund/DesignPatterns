using AccountabilityLib;
using Bowling.Models;
using Microsoft.EntityFrameworkCore;

namespace CorneliasBowlinghall.EFDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Party> Parties { get; set; }
    }
}
