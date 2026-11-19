namespace BundesligaStndings_Backend_.Dto
{
    public class StandingDto
    {
        public int Position { get; set; }
        public string Zone { get; set; } = "";
        public int TeamId { get; set; }
        public string TeamName { get; set; } = "";
        public string IconUrl { get; set; } = "";
        public int Played { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDiff { get; set; }
        public int Points { get; set; }
    }
}
