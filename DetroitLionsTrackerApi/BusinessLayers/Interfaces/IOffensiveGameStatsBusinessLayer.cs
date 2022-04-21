using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayers.Interfaces
{
    public interface IOffensiveGameStatsBusinessLayer
    {
        Task<OffensiveGameStats> CreateOffensiveGameStats(OffensiveGameStatsRequest offensiveGameStatsRequest);
        Task<OffensiveGameStats> UpdateOffensiveGameStats(long gameId, long playerId, OffensiveGameStatsRequest offensiveGameStatsRequest);
        IAsyncEnumerable<OffensiveGameStats> GetOffensiveGameStatsByFilter(OffensiveGameStatsFilterParameters filters);
        Task DeleteOffensiveGameStats(long gameId, long playerId);
    }
}
