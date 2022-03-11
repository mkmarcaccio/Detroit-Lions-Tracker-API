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
        [Key]
        [Column("SpecialTeamsGameStatsId")]
        public long SpecialTeamsGameStatsId { get; init; }

        [Column("GameId")]
        public long GameId { get; init; }

        [Column("PlayerId")]
        public long PlayerId { get; init; }

        [Column("FGAttempts")]
        public int FGAttempts { get; init; }

        [Column("FGMade")]
        public int FGMade { get; init; }

        [Column("XPAttempts")]
        public int XPAttempts { get; init; }

        [Column("XPMade")]
        public int XPMade { get; init; }

        [Column("Punts")]
        public int Punts { get; init; }

        [Column("PuntYards")]
        public int PuntYards { get; init; }

        [Column("KickReturns")]
        public int KickReturns { get; init; }

        [Column("KickReturnYards")]
        public int KickReturnYards { get; init; }

        [Column("PuntReturns")]
        public int PuntReturns { get; init; }

        [Column("PuntReturnYards")]
        public int PuntReturnYards { get; init; }

        [Column("Touchdowns")]
        public int Touchdowns { get; init; }

        public virtual Player Player { get; set; }

        public virtual Game Game { get; set; }
    }
}
