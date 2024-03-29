﻿using DetroitLionsTrackerApi.DataLayer.Context;
using DetroitLionsTrackerApi.DataLayer.Interfaces;
using DetroitLionsTrackerApi.Models;
using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.DataLayer
{
    [ExcludeFromCodeCoverage]
    public class GameDataLayer : IGameDataLayer
    {
        private readonly DetroitLionsTrackerDbContext _context;

        public GameDataLayer(DetroitLionsTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateGame(GameRequest gameRequest)
        {
            var game = new Game
            {
                GameId = gameRequest.GameId,
                SeasonId = gameRequest.SeasonId,
                Opponent = gameRequest.Opponent,
                Date = gameRequest.Date,
                Outcome = (Outcome)gameRequest.Outcome,
                Score = gameRequest.Score,

            };
            var gameEntry = _context.Games.Add(game);

            await _context.SaveChangesAsync();

            return gameEntry.Entity;
        }

        public async Task<Game> UpdateGame(long gameId, GameRequest gameRequest)
        {
            var game = await _context.Games
                .AsNoTracking()
                .SingleOrDefaultAsync(g => g.GameId.Equals(gameId));

            if (game == null)
            {
                throw new ArgumentException($"gameId({gameId}) not found.");
            }

            var gameEntry = _context.Update(game with
            {
                GameId = gameRequest.GameId,
                SeasonId = gameRequest.SeasonId,
                Opponent = gameRequest.Opponent,
                Date = gameRequest.Date,
                Outcome = (Outcome)gameRequest.Outcome,
                Score = gameRequest.Score,
            });

            await _context.SaveChangesAsync();

            return gameEntry.Entity;
        }

        public IAsyncEnumerable<Game> GetGamesByFilter(GameFilterParameters filters)
        {
            return _context.Games
                .Where(g => filters.GameId == null || g.GameId == filters.GameId)
                .Where(g => filters.SeasonId == null || g.SeasonId == filters.SeasonId)
                .Where(g => filters.Opponent == null || g.Opponent == filters.Opponent)
                .Where(g => filters.Date == null || g.Date == filters.Date)
                .Where(g => filters.Outcome == null || g.Outcome == (Outcome)filters.Outcome)
                .Where(g => filters.Score == null || g.Score == filters.Score)
                .OrderByDescending(g => g.Date)
                .AsAsyncEnumerable();
        }

        public async Task DeleteGame(long gameId)
        {
            _context.Games
                .Remove(await GetGameByGameId(gameId));

            await _context.SaveChangesAsync();
        }

        public async Task<Game> GetGameByGameId(long gameId)
        {
            var game = await _context.Games
                .AsNoTracking()
                .FirstOrDefaultAsync(game => game.GameId == gameId);

            if (game == null)
            {
                throw new ArgumentException($"GameId ({gameId}) not found.");
            }

            return game;
        }
    }
}
