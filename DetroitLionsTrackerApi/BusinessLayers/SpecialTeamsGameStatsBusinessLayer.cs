using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayers
{
    public class SpecialTeamsGameStatsBusinessLayer : ISpecialTeamsGameStatsBusinessLayer
    {
        private readonly ISpecialTeamsGameStatsDataLayer _specialTeamsGameStatsDataLayer;

        public SpecialTeamsGameStatsBusinessLayer(ISpecialTeamsGameStatsDataLayer specialTeamsGameStatsDataLayer)
        {
            _specialTeamsGameStatsDataLayer = specialTeamsGameStatsDataLayer;
        }

        public Task<SpecialTeamsGameStats> CreateSpecialTeamsGameStats(SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest) =>
            _specialTeamsGameStatsDataLayer.CreateSpecialTeamsGameStats(specialTeamsGameStatsRequest);

        public Task<SpecialTeamsGameStats> UpdateSpecialTeamsGameStats(long gameId, long playerId, SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest) =>
            _specialTeamsGameStatsDataLayer.UpdateSpecialTeamsGameStats(gameId, playerId, specialTeamsGameStatsRequest);

        public IAsyncEnumerable<SpecialTeamsGameStats> GetSpecialTeamsGameStatsByFilter(SpecialTeamsGameStatsFilterParameters filters) =>
            _specialTeamsGameStatsDataLayer.GetSpecialTeamsGameStatsByFilter(filters);

        public async Task DeleteSpecialTeamsGameStats(long gameId, long playerId)
        {
            try
            {
                await _specialTeamsGameStatsDataLayer.DeleteSpecialTeamsGameStats(gameId, playerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
