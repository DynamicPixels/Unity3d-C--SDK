using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Party.Models;

namespace DynamicPixels.GameService.Services.Party
{
    public interface IParty
    {
        Task<List<Party>> GetParties<T>(T param) where T : GetPartiesParams;
        Task<Party> CreateParty<T>(T param) where T : CreatePartyParams;
        Task<List<Party>> GetSubscribedParties<T>(T param) where T : GetSubscribedPartiesParams;
        Task<PartyMember> JoinToParty<T>(T param) where T : JoinToPartyParams;
        Task<bool> LeaveParty<T>(T param) where T : LeavePartyParams;
        Task<Party> GetPartyById<T>(T param) where T : GetPartyByIdParams;
        Task<List<RichPartyMember>> GetPartyMembers<T>(T param) where T : GetPartyMembersParams;
        Task<PartyMember> SetMemberVariables<T>(T param) where T : SetMemberVariablesParams;
        Task<List<PartyMember>> GetPartyWaitingMembers<T>(T param) where T : GetPartyWaitingMembersParams;
        Task<Party> EditParty<T>(T param) where T : EditPartyParams;
        Task<PartyMember> AcceptJoining<T>(T param) where T : AcceptJoiningParams;
        Task<PartyMember> RejectJoining<T>(T param) where T : RejectJoiningParams;
    }
}
