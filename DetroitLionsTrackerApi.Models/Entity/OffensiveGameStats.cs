using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record OffensiveGameStats
    {
        [Key]
        [Column("OffensiveGameStatsId")]
        public long OffensiveGameStatsId { get; init; }

        [Column("GameId")]
        public long GameId { get; init; }

        [Column("PlayerId")]
        public long PlayerId { get; init; }

        [Column("PassingAttempts")]
        public int PassingAttempts { get; init; }

        [Column("PassingCompletions")]
        public int PassingCompletions { get; init; }

        [Column("PassingYards")]
        public int PassingYards { get; init; }

        [Column("PassingTouchdowns")]
        public int PassingTouchdowns { get; init; }

        [Column("Interceptions")]
        public int Interceptions { get; init; }

        [Column("RushingAttempts")]
        public int RushingAttempts { get; init; }

        [Column("RushingYards")]
        public int RushingYards { get; init; }

        [Column("RushingTouchdowns")]
        public int RushingTouchdowns { get; init; }

        [Column("Fumbles")]
        public int Fumbles { get; init; }

        [Column("Receptions")]
        public int Receptions { get; init; }

        [Column("ReceivingYards")]
        public int ReceivingYards { get; init; }

        [Column("Targets")]
        public int Targets { get; init; }

        [Column("Drops")]
        public int Drops { get; init; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
