using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DetroitLionsTrackerApi.DataLayers
{
    public class OffensiveGameStatsDataLayer : IOffensiveGameStatsDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public OffensiveGameStatsDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<OffensiveGameStats> CreateOffensiveGameStats(OffensiveGameStatsRequest offensiveGameStatsRequest)
        {
            var offensiveGameStats = new OffensiveGameStats
            {
                GameId = offensiveGameStatsRequest.GameId,
                PlayerId = offensiveGameStatsRequest.PlayerId,
                PassingAttempts = offensiveGameStatsRequest.PassingAttempts,
                PassingCompletions = offensiveGameStatsRequest.PassingCompletions,
                PassingYards = offensiveGameStatsRequest.PassingYards,
                PassingTouchdowns = offensiveGameStatsRequest.PassingTouchdowns,
                Interceptions = offensiveGameStatsRequest.Interceptions,
                RushingAttempts = offensiveGameStatsRequest.RushingAttempts,
                RushingYards = offensiveGameStatsRequest.RushingYards,
                RushingTouchdowns = offensiveGameStatsRequest.RushingTouchdowns,
                Fumbles = offensiveGameStatsRequest.Fumbles,
                Receptions = offensiveGameStatsRequest.Receptions,
                ReceivingYards = offensiveGameStatsRequest.ReceivingYards,
                ReceivingTouchdowns = offensiveGameStatsRequest.ReceivingTouchdowns,
                Targets = offensiveGameStatsRequest.Targets,
                Drops = offensiveGameStatsRequest.Drops,

            };
            var offensiveGameStatsEntry = _context.OffensiveGameStats.Add(offensiveGameStats);

            await _context.SaveChangesAsync();

            return offensiveGameStatsEntry.Entity;
        }

        public async Task<OffensiveGameStats> UpdateOffensiveGameStats(long gameId, long playerId, OffensiveGameStatsRequest offensiveGameStatsRequest)
        {
            var offensiveGameStats = await _context.OffensiveGameStats
                .AsNoTracking()
                .Include(o => o.Player)
                .SingleOrDefaultAsync(o => o.GameId.Equals(gameId) && o.PlayerId.Equals(playerId));
                

            if (offensiveGameStats == null)
            {
                throw new ArgumentException($"gameId({gameId}) with playerId({playerId}) not found.");
            }

            var offensiveGameStatsEntry = _context.Update(offensiveGameStats with
            {
                GameId = offensiveGameStatsRequest.GameId,
                PlayerId = offensiveGameStatsRequest.PlayerId,
                PassingAttempts = offensiveGameStatsRequest.PassingAttempts,
                PassingCompletions = offensiveGameStatsRequest.PassingCompletions,
                PassingYards = offensiveGameStatsRequest.PassingYards,
                PassingTouchdowns = offensiveGameStatsRequest.PassingTouchdowns,
                Interceptions = offensiveGameStatsRequest.Interceptions,
                RushingAttempts = offensiveGameStatsRequest.RushingAttempts,
                RushingYards = offensiveGameStatsRequest.RushingYards,
                RushingTouchdowns = offensiveGameStatsRequest.RushingTouchdowns,
                Fumbles = offensiveGameStatsRequest.Fumbles,
                Receptions = offensiveGameStatsRequest.Receptions,
                ReceivingYards = offensiveGameStatsRequest.ReceivingYards,
                ReceivingTouchdowns = offensiveGameStatsRequest.ReceivingTouchdowns,
                Targets = offensiveGameStatsRequest.Targets,
                Drops = offensiveGameStatsRequest.Drops,
            });

            await _context.SaveChangesAsync();
            //return GetOffensiveGameStatsByFilter(new OffensiveGameStatsFilterParameters
            //{
            //    PlayerId = offensiveGameStatsRequest.PlayerId
            //});

            return offensiveGameStatsEntry.Entity;
        }

        public IAsyncEnumerable<OffensiveGameStats> GetOffensiveGameStatsByFilter(OffensiveGameStatsFilterParameters filters)
        {
            return _context.OffensiveGameStats
                .Where(o => filters.GameId == null || o.GameId == filters.GameId)
                .Where(o => filters.PlayerId == null || o.PlayerId == filters.PlayerId)
                .Where(o => filters.PassingAttempts == null || o.PassingAttempts == filters.PassingAttempts)
                .Where(o => filters.PassingCompletions == null || o.PassingCompletions == filters.PassingCompletions)
                .Where(o => filters.PassingYards == null || o.PassingYards == filters.PassingYards)
                .Where(o => filters.PassingTouchdowns == null || o.PassingTouchdowns == filters.PassingTouchdowns)
                .Where(o => filters.Interceptions == null || o.Interceptions == filters.Interceptions)
                .Where(o => filters.RushingAttempts == null || o.RushingAttempts == filters.RushingAttempts)
                .Where(o => filters.RushingYards == null || o.RushingYards == filters.RushingYards)
                .Where(o => filters.RushingTouchdowns == null || o.RushingTouchdowns == filters.RushingTouchdowns)
                .Where(o => filters.Fumbles == null || o.Fumbles == filters.Fumbles)
                .Where(o => filters.Receptions == null || o.Receptions == filters.Receptions)
                .Where(o => filters.ReceivingYards == null || o.ReceivingYards == filters.ReceivingYards)
                .Where(o => filters.ReceivingTouchdowns == null || o.ReceivingTouchdowns == filters.ReceivingTouchdowns)
                .Where(o => filters.Targets == null || o.Targets == filters.Targets)
                .Where(o => filters.Drops == null || o.Drops == filters.Drops)
                .OrderByDescending(o => o.GameId)
                .Include(o => o.Player)
                .Include(o => o.Game)
                .AsAsyncEnumerable();
        }

        public async Task DeleteOffensiveGameStats(long gameId, long playerId)
        {
            _context.OffensiveGameStats
                .Remove(await GetOffensiveGameStatsByGameIdPlayerId(gameId, playerId));

            await _context.SaveChangesAsync();
        }

        public async Task<OffensiveGameStats> GetOffensiveGameStatsByGameIdPlayerId(long gameId, long playerId)
        {
            var offensiveGameStats = await _context.OffensiveGameStats
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.GameId == gameId && o.PlayerId == playerId);

            if (offensiveGameStats == null)
            {
                throw new ArgumentException($"GameId ({gameId}) with PlayerId ({playerId}) not found.");
            }

            return offensiveGameStats;
        }
    }
}
