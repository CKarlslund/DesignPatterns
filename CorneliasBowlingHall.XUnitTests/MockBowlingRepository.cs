using System;

namespace CorneliasBowlingHall.XUnitTests
{
    public class MockBowlingRepository : IBowlingRepository
    {
        public void CreateCompetition(string competitionName, Guid competitionId)
        {
            var competition = new Competition()
            {
                Id = competitionId,
                Name = competitionName,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(7)
            };

        }
    }

}
