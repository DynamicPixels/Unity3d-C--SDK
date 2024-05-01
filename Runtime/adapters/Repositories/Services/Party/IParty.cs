using System.Threading.Tasks;
using GameService.Client.Sdk.Adapters.Services.Services.Party;
using GameService.Client.Sdk.Models.inputs;
using GameService.Client.Sdk.Models.outputs;

namespace GameService.Client.Sdk.Adapters.Repositories.Services.Party
{
    public interface IPartyRepository
    {
        Task<RowListResponse<Adapters.Services.Services.Party.Party>> GetParties<T>(T param) where T: GetPartiesParams;
        Task<RowResponse<Adapters.Services.Services.Party.Party>> CreateParty<T>(T param) where T: CreatePartyParams;
        Task<RowListResponse<Adapters.Services.Services.Party.Party>> GetSubscribedParties<T>(T param) where T: GetSubscribedPartiesParams;
        Task<RowResponse<Adapters.Services.Services.Party.Party>> GetPartyById<T>(T param) where T: GetPartyByIdParams;
        Task<RowResponse<PartyMember>> JoinToParty<T>(T param) where T: JoinToPartyParams;
        Task<RowResponse<Adapters.Services.Services.Party.Party>> EditParty<T>(T param) where T: EditPartyParams;
        Task<ActionResponse> LeaveParty<T>(T param) where T: LeavePartyParams;
        Task<RowListResponse<RichPartyMember>> GetPartyMembers<T>(T param) where T: GetPartyMembersParams;
        Task<RowListResponse<PartyMember>> GetPartyWaitingMembers<T>(T param) where T: GetPartyWaitingMembersParams;
        Task<RowResponse<PartyMember>> AcceptJoining<T>(T param) where T: AcceptJoiningParams;
        Task<RowResponse<PartyMember>> RejectJoining<T>(T param) where T: RejectJoiningParams;

    }
}