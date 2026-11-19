using BundesligaStndings_Backend_.Data.ExternalApi;
using BundesligaStndings_Backend_.Dto;
using BundesligaStndings_Backend_.Models;

namespace BundesligaStndings_Backend_.Services
{
    public class FootballService : IFootballService
    {
        private readonly IFootballApiClient _api;

        public FootballService(IFootballApiClient api)
        {
            _api = api;
        }

        public async Task<List<StandingDto>> GetTableAsync()
        {
            // OpenLigaDB sends the teams already sorted: 1st place first
            List<Team> teams = await _api.GetTableAsync();

            List<StandingDto> rows = new List<StandingDto>();
            int position = 1;

            foreach (Team team in teams)
            {
                rows.Add(new StandingDto
                {
                    Position = position,
                    Zone = GetZone(position),
                    TeamId = team.Id,
                    TeamName = team.Name,
                    IconUrl = team.IconUrl,
                    Played = team.Played,
                    Won = team.Won,
                    Draw = team.Draw,
                    Lost = team.Lost,
                    GoalsFor = team.GoalsFor,
                    GoalsAgainst = team.GoalsAgainst,
                    GoalDiff = team.GoalDiff,
                    Points = team.Points
                });
                position++;
            }

            return rows;
        }

        public async Task<List<TeamDto>> GetTeamsAsync()
        {
            List<Team> teams = await _api.GetTableAsync();

            List<TeamDto> result = new List<TeamDto>();
            foreach (Team team in teams.OrderBy(t => t.Name))
            {
                result.Add(new TeamDto { Id = team.Id, Name = team.Name });
            }

            return result;
        }

        // Bundesliga rules: which places go to Europe and which go down
        private string GetZone(int position)
        {
            if (position <= 4) return "ucl";          // Champions League
            if (position == 5) return "uel";          // Europa League
            if (position == 6) return "uecl";         // Conference League
            if (position == 16) return "playoff";     // relegation play-off
            if (position >= 17) return "relegation";  // relegated
            return "";
        }
    }
}
