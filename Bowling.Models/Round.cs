using System;
using System.Collections.Generic;

namespace Bowling.Models
{
    public class Round
    {
        public Round()
        {
                AddPlayer1Series(new Series());
                AddPlayer2Series(new Series());
        }

        private void AddPlayer2Series(Series series)
        {
            if (Player1Series.Count > 3)
            {
                throw new NotImplementedException();
            }
        }

        private void AddPlayer1Series(Series series)
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; set; }

        public int Player1SeriesId { get; set; }
        public List<Series> Player1Series { get; set; }

        public int Player2SeriesId { get; set; }
        public List<Series> Player2Series { get; set; }
    }
}
