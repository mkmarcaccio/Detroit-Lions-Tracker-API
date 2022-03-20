using System.Text.Json.Serialization;

namespace DetroitLionsTrackerApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GameOutcome
    {
        Win,
        Loss,
        Tie
    }
}
