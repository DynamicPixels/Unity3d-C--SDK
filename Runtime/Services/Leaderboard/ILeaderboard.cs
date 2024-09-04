using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicPixels.GameService.Services.Leaderboard.Models;

namespace DynamicPixels.GameService.Services.Leaderboard
{
    public interface ILeaderboard
    {
        /// <summary>
        /// Retrieves a list of leaderboards based on the provided parameters.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter, constrained to GetLeaderboardsParams.</typeparam>
        /// <param name="param">The parameters used to filter and fetch the leaderboards.</param>
        /// <returns>A task representing the asynchronous operation, with a list of Leaderboards as the result.</returns>
        Task<List<Models.Leaderboard>> GetLeaderboards<T>(T param) where T : GetLeaderboardsParams;

        /// <summary>
        /// Obtains scores for individual users as specified by the input parameters.
        /// </summary>
        /// <typeparam name="TInput">The type of the input parameter, constrained to GetScoresParams.</typeparam>
        /// <typeparam name="TOutput">The type of the output result, constrained to UserScore.</typeparam>
        /// <param name="param">The parameters used to filter and fetch user scores.</param>
        /// <returns>A task representing the asynchronous operation, with a list of UserScores as the result.</returns>
        Task<List<TOutput>> GetUsersScores<TInput, TOutput>(TInput param)
            where TInput : GetScoresParams where TOutput : UserScore;

        /// <summary>
        /// Fetches scores for different parties (e.g., teams or groups) according to the given parameters.
        /// </summary>
        /// <typeparam name="TInput">The type of the input parameter, constrained to GetScoresParams.</typeparam>
        /// <typeparam name="TOutput">The type of the output result, constrained to PartyScore.</typeparam>
        /// <param name="param">The parameters used to filter and fetch party scores.</param>
        /// <returns>A task representing the asynchronous operation, with a list of PartyScores as the result.</returns>
        Task<List<TOutput>> GetPartiesScores<TInput, TOutput>(TInput param)
            where TInput : GetScoresParams where TOutput : PartyScore;

        /// <summary>
        /// Gathers scores specifically for friends of the current user.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter, constrained to GetFriendsScoresParams.</typeparam>
        /// <param name="param">The parameters used to filter and fetch friends' scores.</param>
        /// <returns>A task representing the asynchronous operation, with a list of UserScores as the result.</returns>
        Task<List<UserScore>> GetFriendsScores<T>(T param) where T : GetFriendsScoresParams;

        /// <summary>
        /// Retrieves the score of the current user based on the input parameters.
        /// </summary>
        /// <typeparam name="TInput">The type of the input parameter, constrained to GetCurrentUserScoreParams.</typeparam>
        /// <typeparam name="TOutput">The type of the output result, constrained to UserScore.</typeparam>
        /// <param name="param">The parameters used to fetch the current user's score.</param>
        /// <returns>A task representing the asynchronous operation, with the user's score as the result.</returns>
        Task<TOutput> GetMyScore<TInput, TOutput>(TInput param) where TInput : GetCurrentUserScoreParams
            where TOutput : UserScore;

        /// <summary>
        /// Submits a user's score and returns the result.
        /// </summary>
        /// <typeparam name="TInput">The type of the input parameter, constrained to SubmitScoreParams.</typeparam>
        /// <typeparam name="TOutput">The type of the output result, constrained to UserScore.</typeparam>
        /// <param name="param">The parameters used to submit the user's score.</param>
        /// <returns>A task representing the asynchronous operation, with the submitted score as the result.</returns>
        Task<TOutput> SubmitScore<TInput, TOutput>(TInput param)
            where TInput : SubmitScoreParams where TOutput : UserScore;
    }
}