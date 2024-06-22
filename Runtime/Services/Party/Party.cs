using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Party.Models;
using DynamicPixels.GameService.Services.Party.Repositories;

namespace DynamicPixels.GameService.Services.Party
{
    public class PartyService : IParty
    {
        private IPartyRepository _repository;
        public PartyService()
        {
            _repository = new PartyRepository();
        }

        public async Task<List<Party>> GetParties<T>(T param) where T : GetPartiesParams
        {
            var result = await _repository.GetParties(param);
            return result.List;
        }

        public async Task<Party> CreateParty<T>(T param) where T : CreatePartyParams
        {
            var result = await _repository.CreateParty(param);
            return result.Row;
        }

        public async Task<List<Party>> GetSubscribedParties<T>(T param) where T : GetSubscribedPartiesParams
        {
            var result = await _repository.GetSubscribedParties(param);
            return result.List;
        }

        public async Task<PartyMember> JoinToParty<T>(T param) where T : JoinToPartyParams
        {
            var result = await _repository.JoinToParty(param);
            return result.Row;
        }

        public async Task<bool> LeaveParty<T>(T param) where T : LeavePartyParams
        {
            var result = await _repository.LeaveParty(param);
            return result.Affected > 0;
        }

        public async Task<Party> GetPartyById<T>(T param) where T : GetPartyByIdParams
        {
            var result = await _repository.GetPartyById(param);
            return result.Row;
        }

        public async Task<List<RichPartyMember>> GetPartyMembers<T>(T param) where T : GetPartyMembersParams
        {
            var result = await _repository.GetPartyMembers(param);
            return result.List;
        }

        public async Task<PartyMember> SetMemberVariables<T>(T param) where T : SetMemberVariablesParams
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PartyMember>> GetPartyWaitingMembers<T>(T param) where T : GetPartyWaitingMembersParams
        {
            var result = await _repository.GetPartyWaitingMembers(param);
            return result.List;
        }

        public async Task<Party> EditParty<T>(T param) where T : EditPartyParams
        {
            var result = await _repository.EditParty(param);
            return result.Row;
        }

        public async Task<PartyMember> AcceptJoining<T>(T param) where T : AcceptJoiningParams
        {
            var result = await _repository.AcceptJoining(param);
            return result.Row;
        }

        public async Task<PartyMember> RejectJoining<T>(T param) where T : RejectJoiningParams
        {
            var result = await _repository.RejectJoining(param);
            return result.Row;
        }
    }
}