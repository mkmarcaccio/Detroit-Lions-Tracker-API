namespace DetroitLionsTrackerApi.Models
{
    public record SeasonFilterParameters
    {
        public long? SeasonId { get; init; }
        public int? Year { get; init; }
        public string? Record { get; init; }
    }
}
