using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DetroitLionsTrackerApi.DataLayers
{
    public class DefensiveGameStatsDataLayer : IDefensiveGameStatsDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public DefensiveGameStatsDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<DefensiveGameStats> CreateDefensiveGameStats(DefensiveGameStatsRequest defensiveGameStatsRequest)
        {
            var defensiveGameStats = new DefensiveGameStats
            {
                GameId = defensiveGameStatsRequest.GameId,
                PlayerId = defensiveGameStatsRequest.PlayerId,
                Tackles = defensiveGameStatsRequest.Tackles,
                TacklesForLoss = defensiveGameStatsRequest.TacklesForLoss,
                Sacks = defensiveGameStatsRequest.Sacks,
                ForcedFumbles = defensiveGameStatsRequest.ForcedFumbles,
                FumblesRecovered = defensiveGameStatsRequest.FumblesRecovered,
                Interceptions = defensiveGameStatsRequest.Interceptions,
                IntYards = defensiveGameStatsRequest.IntYards,
                PassesDeflected = defensiveGameStatsRequest.PassesDeflected,
                Touchdowns = defensiveGameStatsRequest.Touchdowns,
                Safeties = defensiveGameStatsRequest.Safeties,

            };
            var defensiveGameStatsEntry = _context.DefensiveGameStats.Add(defensiveGameStats);

            await _context.SaveChangesAsync();

            return defensiveGameStatsEntry.Entity;
        }

        public async Task<DefensiveGameStats> UpdateDefensiveGameStats(long gameId, long playerId, DefensiveGameStatsRequest defensiveGameStatsRequest)
        {
            var defensiveGameStats = await _context.DefensiveGameStats
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.GameId.Equals(gameId) && d.PlayerId.Equals(playerId));

            if (defensiveGameStats == null)
            {
                throw new ArgumentException($"gameId({gameId}) with playerId({playerId}) not found.");
            }

            var defensiveGameStatsEntry = _context.Update(defensiveGameStats with
            {
                GameId = defensiveGameStatsRequest.GameId,
                PlayerId = defensiveGameStatsRequest.PlayerId,
                Tackles = defensiveGameStatsRequest.Tackles,
                TacklesForLoss = defensiveGameStatsRequest.TacklesForLoss,
                Sacks = defensiveGameStatsRequest.Sacks,
                ForcedFumbles = defensiveGameStatsRequest.ForcedFumbles,
                FumblesRecovered = defensiveGameStatsRequest.FumblesRecovered,
                Interceptions = defensiveGameStatsRequest.Interceptions,
                IntYards = defensiveGameStatsRequest.IntYards,
                PassesDeflected = defensiveGameStatsRequest.PassesDeflected,
                Touchdowns = defensiveGameStatsRequest.Touchdowns,
                Safeties = defensiveGameStatsRequest.Safeties,
            });

            await _context.SaveChangesAsync();

            return defensiveGameStatsEntry.Entity;
        }

        public IAsyncEnumerable<DefensiveGameStats> GetDefensiveGameStatsByFilter(DefensiveGameStatsFilterParameters filters)
        {
            return _context.DefensiveGameStats
                .Where(d => filters.GameId == null || d.GameId == filters.GameId)
                .Where(d => filters.PlayerId == null || d.PlayerId == filters.PlayerId)
                .Where(d => filters.Tackles == null || d.Tackles == filters.Tackles)
                .Where(d => filters.TacklesForLoss == null || d.TacklesForLoss == filters.TacklesForLoss)
                .Where(d => filters.Sacks == null || d.Sacks == filters.Sacks)
                .Where(d => filters.ForcedFumbles == null || d.ForcedFumbles == filters.ForcedFumbles)
                .Where(d => filters.FumblesRecovered == null || d.FumblesRecovered == filters.FumblesRecovered)
                .Where(d => filters.Interceptions == null || d.Interceptions == filters.Interceptions)
                .Where(d => filters.IntYards == null || d.IntYards == filters.IntYards)
                .Where(d => filters.PassesDeflected == null || d.PassesDeflected == filters.PassesDeflected)
                .Where(d => filters.Touchdowns == null || d.Touchdowns == filters.Touchdowns)
                .Where(d => filters.Safeties == null || d.Safeties == filters.Safeties)
                .OrderByDescending(d => d.GameId)
                .AsAsyncEnumerable();
        }

        public async Task DeleteDefensiveGameStats(long gameId, long playerId)
        {
            _context.DefensiveGameStats
                .Remove(await GetDefensiveGameStatsByGameIdPlayerId(gameId, playerId));

            await _context.SaveChangesAsync();
        }

        public async Task<DefensiveGameStats> GetDefensiveGameStatsByGameIdPlayerId(long gameId, long playerId)
        {
            var defensiveGameStats = await _context.DefensiveGameStats
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.GameId == gameId && d.PlayerId == playerId);

            if (defensiveGameStats == null)
            {
                throw new ArgumentException($"GameId ({gameId}) with PlayerId ({playerId}) not found.");
            }

            return defensiveGameStats;
        }
    }
}
