using AccountabilityLib;
using Bowling.Models;
using CorneliasBowlinghall.EFDatabase;
using CorneliasBowlinghall.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorneliasBowlinghall.Tests
{
    public static class CompetitionFaker
    {
        public static List<Competition> Competitions { get; set; }

        public static void GenerateFakeCompetitions(IBowlingRepository bowlingRepository)
        {
            //Lanes
            bowlingRepository.CreateLane("Bananen");
            bowlingRepository.CreateLane("Yxan");
            bowlingRepository.CreateLane("Tulpanen");

            //Create players
            bowlingRepository.CreateParty("Agneta Räserbajs", "790522-5878");
            bowlingRepository.CreateParty("Ahmed Ostbåge", "601111-2415");
            bowlingRepository.CreateParty("Kung Babar", "601111-2415");
            bowlingRepository.CreateParty("Barbro Messmör", "601111-2415");
            bowlingRepository.CreateParty("Ceasar Sallad", "601111-2415");
            bowlingRepository.CreateParty("Carbonara Ciabatta", "601111-2415");

            var player1 = bowlingRepository.FindParty("Agneta").FirstOrDefault();
            var player2 = bowlingRepository.FindParty("Ahmed").FirstOrDefault();
            var player3 = bowlingRepository.FindParty("Babar").FirstOrDefault();
            var player4 = bowlingRepository.FindParty("Barbro").FirstOrDefault();
            var player5 = bowlingRepository.FindParty("Ceasar").FirstOrDefault();
            var player6 = bowlingRepository.FindParty("Carbonara").FirstOrDefault();

            var players = new List<Party>{ player1, player2 };

            //Create competition
            var competition1Id = Guid.NewGuid();
            var competition1StartDate = new DateTime(2017,10,05);
            var competition1EndDate = new DateTime(2017,11,07);

            bowlingRepository.CreateCompetition("FirstCompetition", competition1Id, competition1StartDate, competition1EndDate);

            var firstCompetition = bowlingRepository.FindCompetitions("FirstCompetition").FirstOrDefault();

            //Match for first competition
            bowlingRepository.CreateMatch(firstCompetition, players, 1);

            var match = bowlingRepository.FindMatch(firstCompetition.Id, 1).FirstOrDefault();

            bowlingRepository.AddScore(match, player1, 10);
            bowlingRepository.AddScore(match, player1, 10);
            bowlingRepository.AddScore(match, player1, 10);

            bowlingRepository.AddScore(match, player2, 15);
            bowlingRepository.AddScore(match, player2, 15);
            bowlingRepository.AddScore(match, player2, 15);

            //Second competition
            var competition2Id = Guid.NewGuid();
            var competition2StartDate = new DateTime(2018, 10, 05);
            var competition2EndDate = new DateTime(2018, 11, 07);

            bowlingRepository.CreateCompetition("SecondCompetition", competition2Id, competition2StartDate, competition2EndDate);

            var secondCompetition = bowlingRepository.FindCompetitions("SecondCompetition").FirstOrDefault();

            var players2 = new List<Party>{player1, player3};
            var players3 = new List<Party>{player4, player5,player1};

            //Match for second competition
            bowlingRepository.CreateMatch(secondCompetition, players2, 1);
            bowlingRepository.CreateMatch(secondCompetition, players3, 2);

            var match2 = bowlingRepository.FindMatch(secondCompetition.Id, 1).FirstOrDefault();
            var match3 = bowlingRepository.FindMatch(secondCompetition.Id, 2).FirstOrDefault();

            bowlingRepository.AddScore(match2, player1, 21);
            bowlingRepository.AddScore(match2, player1, 22);
            bowlingRepository.AddScore(match2, player1, 23);

            bowlingRepository.AddScore(match2, player3, 24);
            bowlingRepository.AddScore(match2, player3, 25);
            bowlingRepository.AddScore(match2, player3, 26);

            bowlingRepository.AddScore(match3, player4, 31);
            bowlingRepository.AddScore(match3, player4, 32);
            bowlingRepository.AddScore(match3, player4, 33);

            //bowlingRepository.AddScore(match3, player5, 34);
            //bowlingRepository.AddScore(match3, player5, 35);
            //bowlingRepository.AddScore(match3, player5, 36);

            //bowlingRepository.AddScore(match3, player1, 10);
            //bowlingRepository.AddScore(match3, player1, 10);
            //bowlingRepository.AddScore(match3, player1, 5);

            //Third Competition
            var competition3Id = Guid.NewGuid();
            var competition3StartDate = new DateTime(2018, 05, 05);
            var competition3EndDate = new DateTime(2018, 03, 07);

            bowlingRepository.CreateCompetition("ThirdCompetition", competition3Id, competition3StartDate, competition3EndDate);

            var thirdCompetition = bowlingRepository.FindCompetitions("ThirdCompetition").FirstOrDefault();

            var players4 = new List<Party>{player2,player4};
            //Match for third competition
            bowlingRepository.CreateMatch(thirdCompetition, players, 1);

            var match4 = bowlingRepository.FindMatch(secondCompetition.Id, 1).FirstOrDefault();

            //bowlingRepository.AddScore(match4, player2, 21);
            //bowlingRepository.AddScore(match4, player2, 22);
            //bowlingRepository.AddScore(match4, player2, 23);

            //bowlingRepository.AddScore(match4, player4, 10);
            //bowlingRepository.AddScore(match4, player4, 11);
            //bowlingRepository.AddScore(match4, player4, 12);

        }
    }

    
}
