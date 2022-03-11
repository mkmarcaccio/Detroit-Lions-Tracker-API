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
        [Column("PlayerId")]
        public long PlayerId { get; init; }

        [Column("FirstName")]
        public string FirstName { get; init; }

        [Column("LastName")]
        public string LastName { get; init; }

        [Column("Position")]
        public string Position { get; init; }

        [Column("Unit")]
        public Unit Unit { get; init; }

        [Column("JerseyNumber")]
        public int JerseyNumber { get; init; }

        [Column("DepthChartOrder")]
        public int DepthChartOrder { get; init; }

        [Column("IsOnRoster")]
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
