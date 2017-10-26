using AccountabilityLib;

namespace Bowling.Models
{
    public class Series
    {
        public int Id { get; set; }
        public int SeqNo { get; set; }
        public int Score { get; set; }
        public Party Player { get; set; }
    }
}
