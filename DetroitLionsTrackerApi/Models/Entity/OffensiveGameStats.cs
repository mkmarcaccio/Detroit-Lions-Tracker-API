using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record OffensiveGameStats
    {
        public long GameId { get; init; }

        public long PlayerId { get; init; }

        public int PassingAttempts { get; init; }

        public int PassingCompletions { get; init; }

        public int PassingYards { get; init; }

        public int PassingTouchdowns { get; init; }

        public int Interceptions { get; init; }

        public int RushingAttempts { get; init; }

        public int RushingYards { get; init; }

        public int RushingTouchdowns { get; init; }

        public int Fumbles { get; init; }

        public int Receptions { get; init; }

        public int ReceivingYards { get; init; }

        public int Targets { get; init; }

        public int Drops { get; init; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
