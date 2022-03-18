using DetroitLionsTrackerApi.BusinessLayer.Interfaces;
using DetroitLionsTrackerApi.DataLayer.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;

namespace DetroitLionsTrackerApi.BusinessLayer
{
    public class SeasonBusinessLayer : ISeasonBusinessLayer
    {
        private readonly ISeasonDataLayer _seasonDataLayer;

        public SeasonBusinessLayer(ISeasonDataLayer seasonDataLayer)
        {
            _seasonDataLayer = seasonDataLayer;
        }

        public Task<Season> CreateSeason(SeasonRequest seasonRequest) => _seasonDataLayer.CreateSeason(seasonRequest);
        public Task<Season> UpdateSeason(long seasonId, SeasonRequest seasonRequest) => _seasonDataLayer.UpdateSeason(seasonId, seasonRequest);
        public IAsyncEnumerable<Season> GetSeasonsByFilter(SeasonFilterParameters filters) => _seasonDataLayer.GetSeasonsByFilter(filters);
        
        public async Task DeleteSeason(long seasonId)
        {
            try
            {
                await _seasonDataLayer.DeleteSeason(seasonId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
