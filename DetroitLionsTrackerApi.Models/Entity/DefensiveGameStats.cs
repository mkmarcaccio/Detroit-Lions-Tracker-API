using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record DefensiveGameStats
    {
        [Key]
        [Column("DefensiveGameStatsId")]
        public long DefensiveGameStatsId { get; init; }

        [Column("GameId")]
        public long GameId { get; init; }

        [Column("PlayerId")]
        public long PlayerId { get; init; }

        [Column("Tackles")]
        public int Tackles { get; init; }

        [Column("TacklesForLoss")]
        public int TacklesForLoss { get; init; }

        [Column("Sacks")]
        public int Sacks { get; init; }

        [Column("ForcedFumbles")]
        public int ForcedFumbles { get; init; }

        [Column("FumblesRecovered")]
        public int FumblesRecovered { get; init; }

        [Column("Interceptions")]
        public int Interceptions { get; init; }

        [Column("IntYards")]
        public int IntYards { get; init; }

        [Column("PassesDeflected")]
        public int PassesDeflected { get; init; }

        [Column("Touchdowns")]
        public int Touchdowns { get; init; }

        [Column("Safeties")]
        public int Safeties { get; init; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
