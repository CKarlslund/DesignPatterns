using Bowling.Models;
using CorneliasBowlinghall.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorneliasBowlinghall.Tests
{
    public static class CompetitionFaker
    {
        public static List<Competition> Competitions { get; set; }

        public static List<Competition> GenerateFakeCompetitions(IBowlingRepository bowlingRepository)
        {
            //TODO add competitions
            return new List<Competition>();
        }
    }

    
}
