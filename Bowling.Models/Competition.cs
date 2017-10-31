using System;
using System.Collections.Generic;

namespace Bowling.Models
{
    public class Competition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Match> Matches { get; set; }
    }
}
