using System;
using System.Collections.Generic;

namespace Bowling.Models
{
    public class Lane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LaneNo { get; set; }

        public List<Match> Matches { get; set; }
    }
}
