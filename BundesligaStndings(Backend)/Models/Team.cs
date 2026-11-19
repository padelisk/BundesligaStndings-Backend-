using System.Text.Json.Serialization;

namespace BundesligaStndings_Backend_.Models
{
    public class Team
    {
        [JsonPropertyName("teamInfoId")]
        public int Id { get; set; }

        [JsonPropertyName("teamName")]
        public string Name { get; set; } = "";

        [JsonPropertyName("teamIconUrl")]
        public string IconUrl { get; set; } = "";

        [JsonPropertyName("matches")]
        public int Played { get; set; }

        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }

        [JsonPropertyName("goals")]
        public int GoalsFor { get; set; }

        [JsonPropertyName("opponentGoals")]
        public int GoalsAgainst { get; set; }

        public int GoalDiff { get; set; }
        public int Points { get; set; }
    }
}
