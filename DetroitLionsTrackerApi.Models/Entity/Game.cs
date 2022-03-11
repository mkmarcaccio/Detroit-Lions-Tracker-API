using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record Game
    {
        [Key]
        [Column("GameId")]
        public long GameId { get; init; }

        [Column("SeasonId")]
        public long SeasonId { get; init; }

        [Column("Opponent")]
        public string Opponent { get; init; }

        [Column("Outcome")]
        public Outcome Outcome { get; init; }

        public virtual Season Season { get; set; }

        public virtual ICollection<OffensiveGameStats> OffensiveGameStats { get; init; }

        public virtual ICollection<DefensiveGameStats> DefensiveGameStats { get; init; }

        public virtual ICollection<SpecialTeamsGameStats> SpecialTeamsGameStats { get; init; }
    }

    public enum Outcome
    {
        Win,
        Loss,
        Tie
    }
}
