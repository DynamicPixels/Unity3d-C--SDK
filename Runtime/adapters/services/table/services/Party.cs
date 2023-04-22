using System.Collections.Generic;
using System.Threading.Tasks;
using adapters.repositories.table.services.party;
using models.dto;
using models.inputs;
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

        public async Task<List<Party>> GetParties<T>(T param) where T : GetPartiesParams
        {
            var result = await this._repository.GetParties(param);
            return result.List; 
        }

        public async Task<Party> CreateParty<T>(T param) where T : CreatePartyParams
        {
            var result = await this._repository.CreateParty(param);
            return result.Row;
        }

        public async Task<List<Party>> GetSubscribedParties<T>(T param) where T : GetSubscribedPartiesParams
        {
            var result = await this._repository.GetSubscribedParties(param);
            return result.List;
        }

        public async Task<PartyMember> JoinToParty<T>(T param) where T : JoinToPartyParams
        {
            var result = await this._repository.JoinToParty(param);
            return result.Row;
        }

        public async Task<bool> LeaveParty<T>(T param) where T : LeavePartyParams
        {
            var result = await this._repository.LeaveParty(param);
            return result.Affected > 0;
        }

        public async Task<Party> GetPartyById<T>(T param) where T : GetPartyByIdParams
        {
            var result = await this._repository.GetPartyById(param);
            return result.Row;
        }

        public async Task<List<RichPartyMember>> GetPartyMembers<T>(T param) where T : GetPartyMembersParams
        {
            var result = await this._repository.GetPartyMembers(param);
            return result.List;
        }

        public async Task<PartyMember> SetMemberVariables<T>(T param) where T : SetMemberVariablesParams
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PartyMember>> GetPartyWaitingMembers<T>(T param) where T : GetPartyWaitingMembersParams
        {
            var result = await this._repository.GetPartyWaitingMembers(param);
            return result.List;
        }

        public async Task<Party> EditParty<T>(T param) where T : EditPartyParams
        {
            var result = await this._repository.EditParty(param);
            return result.Row;
        }

        public async Task<PartyMember> AcceptJoining<T>(T param) where T : AcceptJoiningParams
        {
            var result = await this._repository.AcceptJoining(param);
            return result.Row;
        }

        public async Task<PartyMember> RejectJoining<T>(T param) where T : RejectJoiningParams
        {
            var result = await this._repository.RejectJoining(param);
            return result.Row;
        }
    }
}