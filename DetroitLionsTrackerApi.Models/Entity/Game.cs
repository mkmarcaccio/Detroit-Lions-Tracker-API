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
        public long GameId { get; init; }

        public long SeasonId { get; init; }

        public string Opponent { get; init; }

        public DateTime Date { get; init; }

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
