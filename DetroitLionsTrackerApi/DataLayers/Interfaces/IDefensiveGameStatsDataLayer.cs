using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.DataLayers.Interfaces
{
    public interface IDefensiveGameStatsDataLayer
    {
        Task<DefensiveGameStats> CreateDefensiveGameStats(DefensiveGameStatsRequest defensiveGameStatsRequest);
        Task<DefensiveGameStats> UpdateDefensiveGameStats(long gameId, long playerId, DefensiveGameStatsRequest defensiveGameStatsRequest);
        IAsyncEnumerable<DefensiveGameStats> GetDefensiveGameStatsByFilter(DefensiveGameStatsFilterParameters filters);
        Task DeleteDefensiveGameStats(long gameId, long playerId);
    }
}
