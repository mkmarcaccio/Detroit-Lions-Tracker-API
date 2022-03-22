using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models
{
    [ExcludeFromCodeCoverage]
    public record SeasonPlayersRequest
    {
        [Required]
        public long SeasonPlayersId { get; init; }
        public long SeasonId { get; init; }
        public long PlayerId { get; init; }
    }
}
