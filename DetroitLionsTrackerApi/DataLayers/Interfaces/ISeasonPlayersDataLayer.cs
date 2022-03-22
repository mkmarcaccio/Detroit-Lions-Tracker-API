using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.DataLayers.Interfaces
{
    public interface ISeasonPlayersDataLayer
    {
        Task<SeasonPlayers> CreateSeasonPlayers(SeasonPlayersRequest seasonPlayersRequest);
        Task<SeasonPlayers> UpdateSeasonPlayers(long seasonPlayersId, SeasonPlayersRequest seasonPlayersRequest);
        IAsyncEnumerable<SeasonPlayers> GetSeasonPlayersByFilter(SeasonPlayersFilterParameters filters);
        Task DeleteSeasonPlayers(long seasonPlayersId);
    }
}
