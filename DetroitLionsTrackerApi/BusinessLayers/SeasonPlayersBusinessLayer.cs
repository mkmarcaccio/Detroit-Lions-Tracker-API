using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayers
{
    public class SeasonPlayersBusinessLayer : ISeasonPlayersBusinessLayer
    {
        private readonly ISeasonPlayersDataLayer _seasonPlayersDataLayer;

        public SeasonPlayersBusinessLayer(ISeasonPlayersDataLayer seasonPlayersDataLayer)
        {
            _seasonPlayersDataLayer = seasonPlayersDataLayer;
        }

        public Task<SeasonPlayers> CreateSeasonPlayers(SeasonPlayersRequest seasonPlayersRequest) => _seasonPlayersDataLayer.CreateSeasonPlayers(seasonPlayersRequest);
        public Task<SeasonPlayers> UpdateSeasonPlayers(long seasonPlayersId, SeasonPlayersRequest seasonPlayersRequest) => _seasonPlayersDataLayer.UpdateSeasonPlayers(seasonPlayersId, seasonPlayersRequest);
        public IAsyncEnumerable<SeasonPlayers> GetSeasonPlayersByFilter(SeasonPlayersFilterParameters filters) => _seasonPlayersDataLayer.GetSeasonPlayersByFilter(filters);

        public async Task DeleteSeasonPlayers(long seasonPlayersId)
        {
            try
            {
                await _seasonPlayersDataLayer.DeleteSeasonPlayers(seasonPlayersId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
