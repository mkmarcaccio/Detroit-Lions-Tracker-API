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
        public long DefensiveGameStatsId { get; init; }

        public long GameId { get; init; }

        public long PlayerId { get; init; }

        public int Tackles { get; init; }

        public int TacklesForLoss { get; init; }

        public int Sacks { get; init; }

        public int ForcedFumbles { get; init; }

        public int FumblesRecovered { get; init; }

        public int Interceptions { get; init; }

        public int IntYards { get; init; }

        public int PassesDeflected { get; init; }

        public int Touchdowns { get; init; }

        public int Safeties { get; init; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
