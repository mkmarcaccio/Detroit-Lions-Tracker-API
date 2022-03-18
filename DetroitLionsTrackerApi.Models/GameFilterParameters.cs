namespace DetroitLionsTrackerApi.Models
{
    public record GameFilterParameters
    {
        public long? GameId { get; init; }
        public long? SeasonId { get; init; }
        public string? Opponent { get; init; }
        public GameOutcome? Outcome { get; init; }
    }
}
