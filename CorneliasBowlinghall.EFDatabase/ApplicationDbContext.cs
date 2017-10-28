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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Lane> Lanes { get; set; }
    }
}
