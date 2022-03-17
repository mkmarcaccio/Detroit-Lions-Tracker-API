using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetroitLionsTrackerApi.Models
{
    public record SeasonFilterParameters
    {
        public long? SeasonId { get; init; }
        public int? Year { get; init; }
        public string? Record { get; init; }
    }
}
