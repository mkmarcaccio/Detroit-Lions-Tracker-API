using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models
{
    [ExcludeFromCodeCoverage]
    public record SeasonRequest
    {
        [Required]
        public long SeasonId { get; init; }
        [Required]
        public int Year { get; init; }
        public string Record { get; init; }
    }
}
