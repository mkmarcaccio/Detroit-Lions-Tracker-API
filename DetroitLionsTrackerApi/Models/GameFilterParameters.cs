namespace DetroitLionsTrackerApi.Models
{
    public record GameFilterParameters
    {
        public long? GameId { get; init; }
        public long? SeasonId { get; init; }
        public string? Opponent { get; init; }
        public DateTime? Date { get; init; }
        public GameOutcome? Outcome { get; init; }
        public string? Score { get; init; }
    }
}
