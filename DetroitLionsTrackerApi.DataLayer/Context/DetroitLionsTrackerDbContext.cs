using DetroitLionsTrackerApi.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetroitLionsTrackerApi.DataLayer.Context
{
    [ExcludeFromCodeCoverage]
    public class DetroitLionsTrackerDbContext : DbContext
    {
        public DetroitLionsTrackerDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<SeasonPlayers> SeasonPlayers { get; set; }
        
        public DbSet<Game> Games { get; set; }

        public DbSet<OffensiveGameStats> OffensiveGameStats { get; set; }

        public DbSet<DefensiveGameStats> DefensiveGameStats { get; set; }

        public DbSet<SpecialTeamsGameStats> SpecialTeamsGameStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Season Table Objects
            modelBuilder.Entity<Season>()
                .ToTable("Season")
                .HasKey(season => season.SeasonId);

            // Player Table Objects
            modelBuilder.Entity<Player>()
                .ToTable("Player")
                .HasKey(player => player.PlayerId);

            // SeasonPlayers Table Objects
            modelBuilder.Entity<SeasonPlayers>()
                .ToTable("SeasonPlayers")
                .HasKey(seasonPlayers => seasonPlayers.SeasonPlayersId);

            modelBuilder.Entity<SeasonPlayers>()
                .HasOne(seasonPlayers => seasonPlayers.Season)
                .WithMany(season => season.SeasonPlayers)
                .HasForeignKey(seasonPlayers => seasonPlayers.SeasonId);

            modelBuilder.Entity<SeasonPlayers>()
                .HasOne(seasonPlayers => seasonPlayers.Player)
                .WithMany(season => season.SeasonPlayers)
                .HasForeignKey(seasonPlayers => seasonPlayers.PlayerId);

            // Game Table Objects
            modelBuilder.Entity<Game>()
                .ToTable("Game")
                .HasKey(game => game.GameId);

            modelBuilder.Entity<Game>()
                .HasOne(game => game.Season)
                .WithMany(season => season.Games)
                .HasForeignKey(game => game.SeasonId);

            // OffensiveGameStats Table Objects
            modelBuilder.Entity<OffensiveGameStats>()
                .ToTable("OffensiveGameStats")
                .HasKey(offensiveGameStats => offensiveGameStats.OffensiveGameStatsId);

            modelBuilder.Entity<OffensiveGameStats>()
                .HasOne(offensiveGameStats => offensiveGameStats.Game)
                .WithMany(game => game.OffensiveGameStats)
                .HasForeignKey(offensiveGameStats => offensiveGameStats.GameId);

            modelBuilder.Entity<OffensiveGameStats>()
                .HasOne(offensiveGameStats => offensiveGameStats.Player)
                .WithMany(player => player.OffensiveGameStats)
                .HasForeignKey(offensiveGameStats => offensiveGameStats.PlayerId);

            // DefensiveGameStats Table Objects
            modelBuilder.Entity<DefensiveGameStats>()
                .ToTable("DefensiveGameStats")
                .HasKey(defensiveGameStats => defensiveGameStats.DefensiveGameStatsId);

            modelBuilder.Entity<DefensiveGameStats>()
                .HasOne(defensiveGameStats => defensiveGameStats.Game)
                .WithMany(game => game.DefensiveGameStats)
                .HasForeignKey(defensiveGameStats => defensiveGameStats.GameId);

            modelBuilder.Entity<DefensiveGameStats>()
                .HasOne(defensiveGameStats => defensiveGameStats.Player)
                .WithMany(player => player.DefensiveGameStats)
                .HasForeignKey(defensiveGameStats => defensiveGameStats.PlayerId);

            // SpecialTeamsGameStats Table Objects
            modelBuilder.Entity<SpecialTeamsGameStats>()
                .ToTable("SpecialTeamsGameStats")
                .HasKey(specialTeamsGameStats => specialTeamsGameStats.SpecialTeamsGameStatsId);

            modelBuilder.Entity<SpecialTeamsGameStats>()
                .HasOne(specialTeamsGameStats => specialTeamsGameStats.Game)
                .WithMany(game => game.SpecialTeamsGameStats)
                .HasForeignKey(specialTeamsGameStats => specialTeamsGameStats.GameId);

            modelBuilder.Entity<SpecialTeamsGameStats>()
                .HasOne(specialTeamsGameStats => specialTeamsGameStats.Player)
                .WithMany(player => player.SpecialTeamsGameStats)
                .HasForeignKey(specialTeamsGameStats => specialTeamsGameStats.PlayerId);
        }
    }
}
