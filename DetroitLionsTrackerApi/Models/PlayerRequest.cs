﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DetroitLionsTrackerApi.Models
{
    [ExcludeFromCodeCoverage]
    public record PlayerRequest
    {
        [Required]
        public long PlayerId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Position { get; init; }
        public PlayerUnit Unit { get; init; }
        public int JerseyNumber { get; init; }
        public int DepthChartOrder { get; init; }
        public bool IsOnRoster { get; init; }
    }
}
