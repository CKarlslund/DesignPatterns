using System;
using System.Collections.Generic;
using System.Text;
using Bowling.Models;

namespace CorneliasBowlinghall.System
{
    public class BowlingFactory
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
