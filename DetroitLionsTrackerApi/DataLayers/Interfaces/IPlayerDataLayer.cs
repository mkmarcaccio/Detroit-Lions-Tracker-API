using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.DataLayers.Interfaces
{
    public interface IPlayerDataLayer
    {
        Task<Player> CreatePlayer(PlayerRequest playerRequest);
        Task<Player> UpdatePlayer(long playerId, PlayerRequest playerRequest);
        IAsyncEnumerable<Player> GetPlayersByFilter(PlayerFilterParameters filters);
        Task DeletePlayer(long playerId);
    }
}
