using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayer.Interfaces
{
    public interface ISeasonBusinessLayer
    {
        Task<Season> CreateSeason(SeasonRequest seasonRequest);
        Task<Season> UpdateSeason(long seasonId, SeasonRequest seasonRequest);
        IAsyncEnumerable<Season> GetSeasonsByFilter(SeasonFilterParameters filters);
        Task DeleteSeason(long seasonId);
    }
}
