using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record SpecialTeamsGameStats
    {
        public long GameId { get; init; }

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

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
