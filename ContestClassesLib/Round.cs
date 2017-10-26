using System;
using System.Collections.Generic;
using System.Text;

namespace ContestClassesLib
{
    public class Round
    {
        public int Id { get; set; }

        public int Player1SeriesId { get; set; }
        public Series Player1Series { get; set; }

        public int Player2SeriesId { get; set; }
        public Series Player2Series { get; set; }
    }
}
