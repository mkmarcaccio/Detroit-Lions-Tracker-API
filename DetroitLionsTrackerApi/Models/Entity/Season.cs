using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models.Entity
{
    [ExcludeFromCodeCoverage]
    public record Season
    {
        [Key]
        public long SeasonId { get; init; }

        public int Year { get; init; }

        public string Record { get; init; }
        
        public virtual ICollection<SeasonPlayers> SeasonPlayers { get; init; }

        public virtual ICollection<Game> Games { get; init; }
    }
}
