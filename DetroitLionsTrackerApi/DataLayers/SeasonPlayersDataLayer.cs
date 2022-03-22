using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.DataLayers
{
    [ExcludeFromCodeCoverage]
    public class SeasonPlayersDataLayer : ISeasonPlayersDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public SeasonPlayersDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<SeasonPlayers> CreateSeasonPlayers(SeasonPlayersRequest seasonPlayersRequest)
        {
            var seasonPlayers = new SeasonPlayers
            {
                SeasonPlayersId = seasonPlayersRequest.SeasonPlayersId,
                SeasonId = seasonPlayersRequest.SeasonId,
                PlayerId = seasonPlayersRequest.PlayerId,
            };
            var seasonPlayersEntry = _context.SeasonPlayers.Add(seasonPlayers);

            await _context.SaveChangesAsync();

            return seasonPlayersEntry.Entity;
        }

        public async Task<SeasonPlayers> UpdateSeasonPlayers(long seasonPlayersId, SeasonPlayersRequest seasonPlayersRequest)
        {
            var seasonPlayers = await _context.SeasonPlayers
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.SeasonPlayersId.Equals(seasonPlayersId));

            if (seasonPlayers == null)
            {
                throw new ArgumentException($"seasonPlayersId({seasonPlayersId}) not found.");
            }

            var seasonPlayersEntry = _context.Update(seasonPlayers with
            {
                SeasonPlayersId = seasonPlayersRequest.SeasonPlayersId,
                SeasonId = seasonPlayersRequest.SeasonId,
                PlayerId = seasonPlayersRequest.PlayerId,
            });

            await _context.SaveChangesAsync();

            return seasonPlayersEntry.Entity;
        }

        public IAsyncEnumerable<SeasonPlayers> GetSeasonPlayersByFilter(SeasonPlayersFilterParameters filters)
        {
            return _context.SeasonPlayers
                .Where(s => filters.SeasonPlayersId == null || s.SeasonPlayersId == filters.SeasonPlayersId)
                .Where(s => filters.SeasonId == null || s.SeasonId == filters.SeasonId)
                .Where(s => filters.PlayerId == null || s.PlayerId == filters.PlayerId)
                .OrderByDescending(s => s.SeasonPlayersId)
                .AsAsyncEnumerable();
        }

        public async Task DeleteSeasonPlayers(long seasonPlayersId)
        {
            _context.SeasonPlayers
                .Remove(await GetSeasonPlayersBySeasonPlayersId(seasonPlayersId));

            await _context.SaveChangesAsync();
        }

        public async Task<SeasonPlayers> GetSeasonPlayersBySeasonPlayersId(long seasonPlayersId)
        {
            var seasonPlayers = await _context.SeasonPlayers
                .AsNoTracking()
                .FirstOrDefaultAsync(seasonPlayers => seasonPlayers.SeasonPlayersId == seasonPlayersId);

            if (seasonPlayers == null)
            {
                throw new ArgumentException($"SeasonPlayersId ({seasonPlayersId}) not found.");
            }

            return seasonPlayers;
        }
    }
}
