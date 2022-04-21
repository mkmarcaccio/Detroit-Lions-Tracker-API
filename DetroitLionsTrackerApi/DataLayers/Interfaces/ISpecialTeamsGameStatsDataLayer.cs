using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.DataLayers.Interfaces
{
    public interface ISpecialTeamsGameStatsDataLayer
    {
        Task<SpecialTeamsGameStats> CreateSpecialTeamsGameStats(SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest);
        Task<SpecialTeamsGameStats> UpdateSpecialTeamsGameStats(long gameId, long playerId, SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest);
        IAsyncEnumerable<SpecialTeamsGameStats> GetSpecialTeamsGameStatsByFilter(SpecialTeamsGameStatsFilterParameters filters);
        Task DeleteSpecialTeamsGameStats(long gameId, long playerId);
    }
}
