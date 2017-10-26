using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Models
{
    public class LaneBooking
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int LaneId { get; set; }
        public Lane Lane { get; set; }
    }
}
