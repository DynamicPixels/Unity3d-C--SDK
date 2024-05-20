using System.Threading.Tasks;
using DynamicPixels.GameService.Models.outputs;
using DynamicPixels.GameService.Services.Party.Models;

namespace DynamicPixels.GameService.Services.Party.Repositories
{
    public interface IPartyRepository
    {
        Task<RowListResponse<Services.Party.Party>> GetParties<T>(T param) where T : GetPartiesParams;
        Task<RowResponse<Services.Party.Party>> CreateParty<T>(T param) where T : CreatePartyParams;
        Task<RowListResponse<Services.Party.Party>> GetSubscribedParties<T>(T param) where T : GetSubscribedPartiesParams;
        Task<RowResponse<Services.Party.Party>> GetPartyById<T>(T param) where T : GetPartyByIdParams;
        Task<RowResponse<PartyMember>> JoinToParty<T>(T param) where T : JoinToPartyParams;
        Task<RowResponse<Services.Party.Party>> EditParty<T>(T param) where T : EditPartyParams;
        Task<ActionResponse> LeaveParty<T>(T param) where T : LeavePartyParams;
        Task<RowListResponse<RichPartyMember>> GetPartyMembers<T>(T param) where T : GetPartyMembersParams;
        Task<RowListResponse<PartyMember>> GetPartyWaitingMembers<T>(T param) where T : GetPartyWaitingMembersParams;
        Task<RowResponse<PartyMember>> AcceptJoining<T>(T param) where T : AcceptJoiningParams;
        Task<RowResponse<PartyMember>> RejectJoining<T>(T param) where T : RejectJoiningParams;

    }
}