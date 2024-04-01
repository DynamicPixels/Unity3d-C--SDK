using System.Threading.Tasks;
using adapters.services.table.services;
using models.dto;
using models.inputs;
using models.outputs;

namespace adapters.repositories.table.services.party
{
    public interface IPartyRepository
    {
        Task<RowListResponse<Party>> GetParties<T>(T param) where T: GetPartiesParams;
        Task<RowResponse<Party>> CreateParty<T>(T param) where T: CreatePartyParams;
        Task<RowListResponse<Party>> GetSubscribedParties<T>(T param) where T: GetSubscribedPartiesParams;
        Task<RowResponse<Party>> GetPartyById<T>(T param) where T: GetPartyByIdParams;
        Task<RowResponse<PartyMember>> JoinToParty<T>(T param) where T: JoinToPartyParams;
        Task<RowResponse<Party>> EditParty<T>(T param) where T: EditPartyParams;
        Task<ActionResponse> LeaveParty<T>(T param) where T: LeavePartyParams;
        Task<RowListResponse<RichPartyMember>> GetPartyMembers<T>(T param) where T: GetPartyMembersParams;
        Task<RowListResponse<PartyMember>> GetPartyWaitingMembers<T>(T param) where T: GetPartyWaitingMembersParams;
        Task<RowResponse<PartyMember>> AcceptJoining<T>(T param) where T: AcceptJoiningParams;
        Task<RowResponse<PartyMember>> RejectJoining<T>(T param) where T: RejectJoiningParams;

    }
}