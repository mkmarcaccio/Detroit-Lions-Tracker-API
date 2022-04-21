using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models
{
    [ExcludeFromCodeCoverage]
    public record SpecialTeamsGameStatsRequest
    {
        [Required]
        public long GameId { get; init; }
        [Required]
        public long PlayerId { get; init; }
        public int FGAttempts { get; init; }
        public int FGMade { get; init; }
        public int XPAttempts { get; init; }
        public int XPMade { get; init; }
        public int Punts { get; init; }
        public int PuntYards { get; init; }
        public int KickReturns { get; init; }
        public int KickReturnYards { get; init; }
        public int PuntReturns { get; init; }
        public int PuntReturnYards { get; init; }
        public int Touchdowns { get; init; }
    }
}
