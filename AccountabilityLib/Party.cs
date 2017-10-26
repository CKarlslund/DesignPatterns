using System;

namespace AccountabilityLib
{
    public class Party
    {
        public AccountabilityType Type { get; set; }

        public int PartyId { get; set; }

        public string Name { get; set; }

        public string LegalId { get; set; }
    }

    public enum AccountabilityType
    {
        Player
    }
}
