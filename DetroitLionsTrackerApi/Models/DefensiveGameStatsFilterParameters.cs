namespace DetroitLionsTrackerApi.Models
{
    public record DefensiveGameStatsFilterParameters
    {
        public long? GameId { get; init; }
        public long? PlayerId { get; init; }
        public int? Tackles { get; init; }
        public int? TacklesForLoss { get; init; }
        public int? Sacks { get; init; }
        public int? ForcedFumbles { get; init; }
        public int? FumblesRecovered { get; init; }
        public int? Interceptions { get; init; }
        public int? IntYards { get; init; }
        public int? PassesDeflected { get; init; }
        public int? Touchdowns { get; init; }
        public int? Safeties { get; init; }
    }
}
