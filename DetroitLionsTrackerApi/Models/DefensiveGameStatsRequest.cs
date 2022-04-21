using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models
{
    [ExcludeFromCodeCoverage]
    public record DefensiveGameStatsRequest
    {
        [Required]
        public long GameId { get; init; }
        [Required]
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
    }
}
