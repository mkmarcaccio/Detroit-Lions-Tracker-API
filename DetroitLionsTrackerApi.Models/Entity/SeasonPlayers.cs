using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record SeasonPlayers
    {
        [Key]
        [Column("SeasonPlayersId")]
        public long SeasonPlayersId { get; init; }

        [Column("SeasonId")]
        public long SeasonId { get; init; }

        [Column("PlayerId")]
        public long PlayerId { get; init; }

        public Season Season { get; set; }

        public Player Player { get; set; }
    }
}
