using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DetroitLionsTrackerApi.DataLayers
{
    public class SpecialTeamsGameStatsDataLayer : ISpecialTeamsGameStatsDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public SpecialTeamsGameStatsDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<SpecialTeamsGameStats> CreateSpecialTeamsGameStats(SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest)
        {
            var specialTeamsGameStats = new SpecialTeamsGameStats
            {
                GameId = specialTeamsGameStatsRequest.GameId,
                PlayerId = specialTeamsGameStatsRequest.PlayerId,
                FGAttempts = specialTeamsGameStatsRequest.FGAttempts,
                FGMade = specialTeamsGameStatsRequest.FGMade,
                XPAttempts = specialTeamsGameStatsRequest.XPAttempts,
                XPMade = specialTeamsGameStatsRequest.XPMade,
                Punts = specialTeamsGameStatsRequest.Punts,
                PuntYards = specialTeamsGameStatsRequest.PuntYards,
                KickReturns = specialTeamsGameStatsRequest.KickReturns,
                KickReturnYards = specialTeamsGameStatsRequest.KickReturnYards,
                PuntReturns = specialTeamsGameStatsRequest.PuntReturns,
                PuntReturnYards = specialTeamsGameStatsRequest.PuntReturnYards,
                Touchdowns = specialTeamsGameStatsRequest.Touchdowns,
            };
            var specialTeamsGameStatsEntry = _context.SpecialTeamsGameStats.Add(specialTeamsGameStats);

            await _context.SaveChangesAsync();

            return specialTeamsGameStatsEntry.Entity;
        }

        public async Task<SpecialTeamsGameStats> UpdateSpecialTeamsGameStats(long gameId, long playerId, SpecialTeamsGameStatsRequest specialTeamsGameStatsRequest)
        {
            var specialTeamsGameStats = await _context.SpecialTeamsGameStats
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.GameId.Equals(gameId) && s.PlayerId.Equals(playerId));

            if (specialTeamsGameStats == null)
            {
                throw new ArgumentException($"gameId({gameId}) with playerId({playerId}) not found.");
            }

            var specialTeamsGameStatsEntry = _context.Update(specialTeamsGameStats with
            {
                GameId = specialTeamsGameStatsRequest.GameId,
                PlayerId = specialTeamsGameStatsRequest.PlayerId,
                FGAttempts = specialTeamsGameStatsRequest.FGAttempts,
                FGMade = specialTeamsGameStatsRequest.FGMade,
                XPAttempts = specialTeamsGameStatsRequest.XPAttempts,
                XPMade = specialTeamsGameStatsRequest.XPMade,
                Punts = specialTeamsGameStatsRequest.Punts,
                PuntYards = specialTeamsGameStatsRequest.PuntYards,
                KickReturns = specialTeamsGameStatsRequest.KickReturns,
                KickReturnYards = specialTeamsGameStatsRequest.KickReturnYards,
                PuntReturns = specialTeamsGameStatsRequest.PuntReturns,
                PuntReturnYards = specialTeamsGameStatsRequest.PuntReturnYards,
                Touchdowns = specialTeamsGameStatsRequest.Touchdowns,
            });

            await _context.SaveChangesAsync();

            return specialTeamsGameStatsEntry.Entity;
        }

        public IAsyncEnumerable<SpecialTeamsGameStats> GetSpecialTeamsGameStatsByFilter(SpecialTeamsGameStatsFilterParameters filters)
        {
            return _context.SpecialTeamsGameStats
                .Where(s => filters.GameId == null || s.GameId == filters.GameId)
                .Where(s => filters.PlayerId == null || s.PlayerId == filters.PlayerId)
                .Where(s => filters.FGAttempts == null || s.FGAttempts == filters.FGAttempts)
                .Where(s => filters.FGMade == null || s.FGMade == filters.FGMade)
                .Where(s => filters.XPAttempts == null || s.XPAttempts == filters.XPAttempts)
                .Where(s => filters.XPMade == null || s.XPMade == filters.XPMade)
                .Where(s => filters.Punts == null || s.Punts == filters.Punts)
                .Where(s => filters.PuntYards == null || s.PuntYards == filters.PuntYards)
                .Where(s => filters.KickReturns == null || s.KickReturns == filters.KickReturns)
                .Where(s => filters.KickReturnYards == null || s.KickReturnYards == filters.KickReturnYards)
                .Where(s => filters.PuntReturns == null || s.PuntReturns == filters.PuntReturns)
                .Where(s => filters.PuntReturnYards == null || s.PuntReturnYards == filters.PuntReturnYards)
                .Where(s => filters.Touchdowns == null || s.Touchdowns == filters.Touchdowns)
                .OrderByDescending(s => s.GameId)
                .Include(s => s.Player)
                .Include(s => s.Game)
                .AsAsyncEnumerable();
        }

        public async Task DeleteSpecialTeamsGameStats(long gameId, long playerId)
        {
            _context.SpecialTeamsGameStats
                .Remove(await GetSpecialTeamsGameStatsByGameIdPlayerId(gameId, playerId));

            await _context.SaveChangesAsync();
        }

        public async Task<SpecialTeamsGameStats> GetSpecialTeamsGameStatsByGameIdPlayerId(long gameId, long playerId)
        {
            var specialTeamsGameStats = await _context.SpecialTeamsGameStats
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.GameId == gameId && s.PlayerId == playerId);

            if (specialTeamsGameStats == null)
            {
                throw new ArgumentException($"GameId ({gameId}) with PlayerId ({playerId}) not found.");
            }

            return specialTeamsGameStats;
        }
    }
}
