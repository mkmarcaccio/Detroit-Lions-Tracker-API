using DetroitLionsTrackerApi.BusinessLayer.Interfaces;
using DetroitLionsTrackerApi.DataLayer.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayer
{
    public class GameBusinessLayer : IGameBusinessLayer
    {
        private readonly IGameDataLayer _gameDataLayer;

        public GameBusinessLayer(IGameDataLayer gameDataLayer)
        {
            _gameDataLayer = gameDataLayer;
        }

        public Task<Game> CreateGame(GameRequest gameRequest) => _gameDataLayer.CreateGame(gameRequest);
        public Task<Game> UpdateGame(long gameId, GameRequest gameRequest) => _gameDataLayer.UpdateGame(gameId, gameRequest);
        public IAsyncEnumerable<Game> GetGamesByFilter(GameFilterParameters filters) => _gameDataLayer.GetGamesByFilter(filters);

        public async Task DeleteGame(long gameId)
        {
            try
            {
                await _gameDataLayer.DeleteGame(gameId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
