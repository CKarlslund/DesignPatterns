using Bowling.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorneliasBowlinghallLib
{
    public static class BowlingFactory
    {
        public static Competition CreateCompetition(Guid competitionId, string competitionName)
        {
            return new Competition()
            {
                Id = competitionId,
                Name = competitionName,
            };
        }
    }
}
