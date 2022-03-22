namespace DetroitLionsTrackerApi.Models
{
    public record SeasonPlayersFilterParameters
    {
        public long? SeasonPlayersId { get; init; }
        public long? SeasonId { get; init; }
        public long? PlayerId { get; init; }
    }
}
