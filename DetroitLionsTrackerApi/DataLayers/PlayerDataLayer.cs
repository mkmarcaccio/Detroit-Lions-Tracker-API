using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayers.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.DataLayers
{
    [ExcludeFromCodeCoverage]
    public class PlayerDataLayer : IPlayerDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public PlayerDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Player> CreatePlayer(PlayerRequest playerRequest)
        {
            var player = new Player
            {
                PlayerId = playerRequest.PlayerId,
                FirstName = playerRequest.FirstName,
                LastName = playerRequest.LastName,
                Position = playerRequest.Position,
                Unit = (Unit)playerRequest.Unit,
                JerseyNumber = playerRequest.JerseyNumber,
                DepthChartOrder = playerRequest.DepthChartOrder,
                IsOnRoster = playerRequest.IsOnRoster,

            };
            var playerEntry = _context.Players.Add(player);

            await _context.SaveChangesAsync();

            return playerEntry.Entity;
        }

        public async Task<Player> UpdatePlayer(long playerId, PlayerRequest playerRequest)
        {
            var player = await _context.Players
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PlayerId.Equals(playerId));

            if (player == null)
            {
                throw new ArgumentException($"playerId({playerId}) not found.");
            }

            var playerEntry = _context.Update(player with
            {
                PlayerId = playerRequest.PlayerId,
                FirstName = playerRequest.FirstName,
                LastName = playerRequest.LastName,
                Position = playerRequest.Position,
                Unit = (Unit)playerRequest.Unit,
                JerseyNumber = playerRequest.JerseyNumber,
                DepthChartOrder = playerRequest.DepthChartOrder,
                IsOnRoster = playerRequest.IsOnRoster,
            });

            await _context.SaveChangesAsync();

            return playerEntry.Entity;
        }

        public IAsyncEnumerable<Player> GetPlayersByFilter(PlayerFilterParameters filters)
        {
            return _context.Players
                .Where(p => filters.PlayerId == null || p.PlayerId == filters.PlayerId)
                .Where(p => filters.FirstName == null || p.FirstName == filters.FirstName)
                .Where(p=> filters.LastName == null || p.LastName == filters.LastName)
                .Where(p => filters.Position == null || p.Position == filters.Position)
                .Where(p => filters.Unit == null || p.Unit == (Unit)filters.Unit)
                .Where(p => filters.JerseyNumber == null || p.JerseyNumber == filters.JerseyNumber)
                .Where(p => filters.DepthChartOrder == null || p.DepthChartOrder == filters.DepthChartOrder)
                .Where(p => filters.IsOnRoster == null || p.IsOnRoster == filters.IsOnRoster)
                .OrderBy(p => p.JerseyNumber)
                .AsAsyncEnumerable();
        }

        public async Task DeletePlayer(long playerId)
        {
            _context.Players
                .Remove(await GetPlayerByPlayerId(playerId));

            await _context.SaveChangesAsync();
        }

        public async Task<Player> GetPlayerByPlayerId(long playerId)
        {
            var player = await _context.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(player => player.PlayerId == playerId);

            if (player == null)
            {
                throw new ArgumentException($"PlayerId ({playerId}) not found.");
            }

            return player;
        }
    }
}
