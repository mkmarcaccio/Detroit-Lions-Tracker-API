using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record Player
    {
        [Key]
        public long PlayerId { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Position { get; init; }

        public Unit Unit { get; init; }

        public int JerseyNumber { get; init; }

        public int DepthChartOrder { get; init; }

        public bool IsOnRoster { get; init; }

        public virtual ICollection<SeasonPlayers> SeasonPlayers { get; init; }

        public virtual ICollection<OffensiveGameStats> OffensiveGameStats { get; init; }

        public virtual ICollection<DefensiveGameStats> DefensiveGameStats { get; init; }

        public virtual ICollection<SpecialTeamsGameStats> SpecialTeamsGameStats { get; init; }
    }

    public enum Unit
    {
        Offense,
        Defense,
        SpecialTeams
    }
}
