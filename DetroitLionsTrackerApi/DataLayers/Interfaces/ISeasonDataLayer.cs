using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetroitLionsTrackerApi.DataLayer.Interfaces
{
    public interface ISeasonDataLayer
    {
        Task<Season> CreateSeason(SeasonRequest seasonRequest);
        Task<Season> UpdateSeason(long seasonId, SeasonRequest seasonRequest);
        IAsyncEnumerable<Season> GetSeasonsByFilter(SeasonFilterParameters filters);
        Task DeleteSeason(long seasonId);
    }
}
