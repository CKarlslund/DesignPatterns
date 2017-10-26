using Bowling.Models;
using CorneliasBowlinghall.Interfaces;
using System;
using Xunit;

namespace CorneliasBowlinghall.Tests
{
    public class MatchTests
    {
        [Fact]
        public void Match_Has_Correct_Winner()
        {
            var sut = new Match()
            {

            };

            var guid = Guid.NewGuid();

            IBowlingRepository fakeRepository = new MemoryBowlingRepository();
        }
    }
}
