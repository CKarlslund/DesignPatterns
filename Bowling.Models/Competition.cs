using System;
using System.Collections.Generic;

namespace Bowling.Models
{
    public class Competition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<Match> Matches { get; set; }
    }
}
