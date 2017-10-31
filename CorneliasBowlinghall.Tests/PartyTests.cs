using CorneliasBowlinghall.Interfaces;
using CorneliasBowlinghall.System;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CorneliasBowlinghall.Tests
{
    public class PartyTests
    {
        private IBowlingRepository _bowlingRepository;

        public PartyTests()
        {
            _bowlingRepository = new MemoryBowlingRepository();
        }

        [Fact]
        public void Find_Party_Works_Correctly()
        {
            
        }
    }
}
