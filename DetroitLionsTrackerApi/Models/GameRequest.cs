using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models
{
    [ExcludeFromCodeCoverage]
    public record GameRequest
    {
        [Required]
        public long GameId { get; init; }
        [Required]
        public long SeasonId { get; init; }
        public string Opponent { get; init; }
        public DateTime Date { get; init; }
        public GameOutcome Outcome { get; init; }
    }
}
