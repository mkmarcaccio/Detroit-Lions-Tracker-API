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
        public long SeasonPlayersId { get; init; }

        public long SeasonId { get; init; }

        public long PlayerId { get; init; }

        public Season Season { get; set; }

        public Player Player { get; set; }
    }
}
