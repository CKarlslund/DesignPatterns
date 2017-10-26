using System;
using System.Dynamic;
using AccountabilityLib;

namespace AccountabilityInterfacesLib
{
    public interface IPartyRepository
    {
        void CreateParty(string name, string legalId);

        void FindPartyTerm(string searchTerm);
    }
}
