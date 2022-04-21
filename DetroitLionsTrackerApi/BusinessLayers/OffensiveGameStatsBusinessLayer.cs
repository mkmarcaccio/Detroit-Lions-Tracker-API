using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayers
{
    public class OffensiveGameStatsBusinessLayer : IOffensiveGameStatsBusinessLayer
    {
        private readonly IOffensiveGameStatsDataLayer _offensiveGameStatsDataLayer;

        public OffensiveGameStatsBusinessLayer(IOffensiveGameStatsDataLayer offensiveGameStatsDataLayer)
        {
            _offensiveGameStatsDataLayer = offensiveGameStatsDataLayer;
        }

        public Task<OffensiveGameStats> CreateOffensiveGameStats(OffensiveGameStatsRequest offensiveGameStatsRequest) =>
            _offensiveGameStatsDataLayer.CreateOffensiveGameStats(offensiveGameStatsRequest);

        public Task<OffensiveGameStats> UpdateOffensiveGameStats(long gameId, long playerId, OffensiveGameStatsRequest offensiveGameStatsRequest) =>
            _offensiveGameStatsDataLayer.UpdateOffensiveGameStats(gameId, playerId, offensiveGameStatsRequest);

        public IAsyncEnumerable<OffensiveGameStats> GetOffensiveGameStatsByFilter(OffensiveGameStatsFilterParameters filters) =>
            _offensiveGameStatsDataLayer.GetOffensiveGameStatsByFilter(filters);

        public async Task DeleteOffensiveGameStats(long gameId, long playerId)
        {
            try
            {
                await _offensiveGameStatsDataLayer.DeleteOffensiveGameStats(gameId, playerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
