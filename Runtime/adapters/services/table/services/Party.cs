using adapters.repositories.table.services.party;
using ports;
using ports.services;
using ports.utils;

namespace adapters.services.table.services
{
    public class PartyService: IParty
    {
        private IPartyRepository _repository;
        public PartyService()
        {
            this._repository = new PartyRepository();
        }
    }
}