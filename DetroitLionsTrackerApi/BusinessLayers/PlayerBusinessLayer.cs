using DetroitLionsTrackerApi.BusinessLayers.Interfaces;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayers
{
    public class PlayerBusinessLayer : IPlayerBusinessLayer
    {
        private readonly IPlayerDataLayer _playerDataLayer;

        public PlayerBusinessLayer(IPlayerDataLayer playerDataLayer)
        {
            _playerDataLayer = playerDataLayer;
        }

        public Task<Player> CreatePlayer(PlayerRequest playerRequest) => _playerDataLayer.CreatePlayer(playerRequest);
        public Task<Player> UpdatePlayer(long playerId, PlayerRequest playerRequest) => _playerDataLayer.UpdatePlayer(playerId, playerRequest);
        public IAsyncEnumerable<Player> GetPlayersByFilter(PlayerFilterParameters filters) => _playerDataLayer.GetPlayersByFilter(filters);

        public async Task DeletePlayer(long playerId)
        {
            try
            {
                await _playerDataLayer.DeletePlayer(playerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
