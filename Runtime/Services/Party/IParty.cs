using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Party.Models;

namespace DynamicPixels.GameService.Services.Party
{
    public interface IParty
    {
        /// <summary>
        /// Retrieves a list of parties based on the specified parameters.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used to filter the parties.</typeparam>
        /// <param name="param">The filtering parameters.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of parties.</returns>
        Task<List<Party>> GetParties<T>(T param) where T : GetPartiesParams;

        /// <summary>
        /// Creates a new party based on the specified parameters.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used to create the party.</typeparam>
        /// <param name="param">The parameters for the party creation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created party.</returns>
        Task<Party> CreateParty<T>(T param) where T : CreatePartyParams;

        /// <summary>
        /// Retrieves a list of parties the user has subscribed to.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used to filter the subscribed parties.</typeparam>
        /// <param name="param">The filtering parameters.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of subscribed parties.</returns>
        Task<List<Party>> GetSubscribedParties<T>(T param) where T : GetSubscribedPartiesParams;

        /// <summary>
        /// Joins a user to a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for joining the party.</typeparam>
        /// <param name="param">The parameters for joining the party.</param>
        /// <returns>A task that represents the asynchronous operation, containing the joined party member.</returns>
        Task<PartyMember> JoinToParty<T>(T param) where T : JoinToPartyParams;

        /// <summary>
        /// Removes a user from a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for leaving the party.</typeparam>
        /// <param name="param">The parameters for leaving the party.</param>
        /// <returns>A task that represents the asynchronous operation, containing a boolean indicating success.</returns>
        Task<bool> LeaveParty<T>(T param) where T : LeavePartyParams;

        /// <summary>
        /// Retrieves a party by its unique identifier.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for fetching the party.</typeparam>
        /// <param name="param">The parameters for fetching the party.</param>
        /// <returns>A task that represents the asynchronous operation, containing the requested party.</returns>
        Task<Party> GetPartyById<T>(T param) where T : GetPartyByIdParams;

        /// <summary>
        /// Retrieves a list of members in a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used to fetch party members.</typeparam>
        /// <param name="param">The parameters for fetching the party members.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of party members with additional details.</returns>
        Task<List<RichPartyMember>> GetPartyMembers<T>(T param) where T : GetPartyMembersParams;

        /// <summary>
        /// Updates variables associated with a party member.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for updating member variables.</typeparam>
        /// <param name="param">The parameters for updating member variables.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated party member.</returns>
        Task<PartyMember> SetMemberVariables<T>(T param) where T : SetMemberVariablesParams;

        /// <summary>
        /// Retrieves a list of members waiting for approval to join a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for fetching waiting members.</typeparam>
        /// <param name="param">The parameters for fetching waiting members.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of waiting members.</returns>
        Task<List<PartyMember>> GetPartyWaitingMembers<T>(T param) where T : GetPartyWaitingMembersParams;

        /// <summary>
        /// Edits the details of a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for editing the party.</typeparam>
        /// <param name="param">The parameters for editing the party.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated party.</returns>
        Task<Party> EditParty<T>(T param) where T : EditPartyParams;

        /// <summary>
        /// Accepts a member's request to join a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for accepting the request.</typeparam>
        /// <param name="param">The parameters for accepting the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the accepted party member.</returns>
        Task<PartyMember> AcceptJoining<T>(T param) where T : AcceptJoiningParams;

        /// <summary>
        /// Rejects a member's request to join a specified party.
        /// </summary>
        /// <typeparam name="T">The type of the parameters used for rejecting the request.</typeparam>
        /// <param name="param">The parameters for rejecting the request.</param>
        /// <returns>A task that represents the asynchronous operation, containing the rejected party member.</returns>
        Task<PartyMember> RejectJoining<T>(T param) where T : RejectJoiningParams;
    }
}
