using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.DataLayer.Interfaces
{
    public interface IGameDataLayer
    {
        Task<Game> CreateGame(GameRequest gameRequest);
        Task<Game> UpdateGame(long gameId, GameRequest gameRequest);
        IAsyncEnumerable<Game> GetGamesByFilter(GameFilterParameters filters);
        Task DeleteGame(long gameId);
    }
}
