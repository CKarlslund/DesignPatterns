using System;
using System.Collections.Generic;
using AccountabilityLib;

namespace Bowling.Models
{
    public class Match
    {
        public int Id { get; set; }

        public Party Winner
        {
            get
            {
                var winningParty = new Party()
                {
                    Name = "Agneta Vinnare"
                };
                //Summera serie 1 för rundor
                //Summera serie 2 för rundor
                return winningParty;
            }
        }    
        
        public List<Series> Series { get; set; }

        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }       

        public int LaneBookingId { get; set; }
        public Lane LaneBooking { get; set; }
    }
}
