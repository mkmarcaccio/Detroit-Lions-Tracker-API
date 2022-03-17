using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayer.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DetroitLionsTrackerApi.DataLayer
{
    public class SeasonDataLayer : ISeasonDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public SeasonDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Season> CreateSeason(SeasonRequest seasonRequest)
        {
            var season = new Season
            {
                SeasonId = seasonRequest.SeasonId,
                Year = seasonRequest.Year,
                Record = seasonRequest.Record,

            };
            var seasonEntry = _context.Seasons.Add(season);

            await _context.SaveChangesAsync();

            return seasonEntry.Entity;
        }

        public async Task<Season> UpdateSeason(long seasonId, SeasonRequest seasonRequest)
        {
            var season = await _context.Seasons
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.SeasonId.Equals(seasonId));

            if (season == null)
            {
                throw new ArgumentException($"seasonId({seasonId}) not found.");
            }

            var seasonEntry = _context.Update(season with
            {
                SeasonId = seasonRequest.SeasonId,
                Year = seasonRequest.Year,
                Record = seasonRequest.Record,
            });

            await _context.SaveChangesAsync();

            return seasonEntry.Entity;
        }

        public IAsyncEnumerable<Season> GetSeasonsByFilter(SeasonFilterParameters filters)
        {
            return _context.Seasons
                .Where(s => filters.SeasonId == null || s.SeasonId == filters.SeasonId)
                .Where(s => filters.Year == null || s.Year == filters.Year)
                .Where(s => filters.Record == null || s.Record.Contains(filters.Record))
                .OrderByDescending(p => p.Year)
                .AsAsyncEnumerable();
        }

        public async Task DeleteSeason(long seasonId)
        {
            _context.Seasons
                .Remove(await GetSeasonBySeasonId(seasonId));

            await _context.SaveChangesAsync();
        }

        public async Task<Season> GetSeasonBySeasonId(long seasonId)
        {
            var season = await _context.Seasons
                .AsNoTracking()
                .FirstOrDefaultAsync(season => season.SeasonId == seasonId);

            if (season == null)
            {
                throw new ArgumentException($"SeasonId ({seasonId}) not found.");
            }

            return season;
        }
    }
}
