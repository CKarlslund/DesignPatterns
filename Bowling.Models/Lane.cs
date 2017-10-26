using System;

namespace Bowling.Models
{
    public class Lane
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int LaneBookingId { get; set; }
        public LaneBooking LaneBooking { get; set; }
    }
}
