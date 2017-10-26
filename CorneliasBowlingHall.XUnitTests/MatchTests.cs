using System;
using Xunit;

namespace CorneliasBowlingHall.XUnitTests
{
    public class CompetitionTests
    {
        [Fact]
        public void Match_Has_Correct_Winner()
        {
            var sut = new Match
            {
                
            };

            var guid = Guid.NewGuid();

            IBowlingRepository fakeRepository = new MockBowlingRepository();
        }

        [Fact]
        public void Match_throws_exception_If_Not_Three_Series()
        {



            Assert
        }
    }
}
