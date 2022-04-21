using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayers
{
    public class DefensiveGameStatsBusinessLayer : IDefensiveGameStatsBusinessLayer
    {
        private readonly IDefensiveGameStatsDataLayer _defensiveGameStatsDataLayer;

        public DefensiveGameStatsBusinessLayer(IDefensiveGameStatsDataLayer defensiveGameStatsDataLayer)
        {
            _defensiveGameStatsDataLayer = defensiveGameStatsDataLayer;
        }

        public Task<DefensiveGameStats> CreateDefensiveGameStats(DefensiveGameStatsRequest defensiveGameStatsRequest) =>
            _defensiveGameStatsDataLayer.CreateDefensiveGameStats(defensiveGameStatsRequest);

        public Task<DefensiveGameStats> UpdateDefensiveGameStats(long gameId, long playerId, DefensiveGameStatsRequest defensiveGameStatsRequest) =>
            _defensiveGameStatsDataLayer.UpdateDefensiveGameStats(gameId, playerId, defensiveGameStatsRequest);

        public IAsyncEnumerable<DefensiveGameStats> GetDefensiveGameStatsByFilter(DefensiveGameStatsFilterParameters filters) =>
            _defensiveGameStatsDataLayer.GetDefensiveGameStatsByFilter(filters);

        public async Task DeleteDefensiveGameStats(long gameId, long playerId)
        {
            try
            {
                await _defensiveGameStatsDataLayer.DeleteDefensiveGameStats(gameId, playerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
