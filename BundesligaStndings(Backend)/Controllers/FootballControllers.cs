using BundesligaStndings_Backend_.Dto;
using BundesligaStndings_Backend_.Services;
using Microsoft.AspNetCore.Mvc;

namespace BundesligaStndings_Backend_.Controllers
{
    [ApiController]
    [Route("api/football")]
    public class FootballController : ControllerBase
    {
        private readonly IFootballService _football;

        public FootballController(IFootballService football)
        {
            _football = football;
        }

        // GET /api/football/standings
        [HttpGet("standings")]
        public async Task<IActionResult> GetStandings()
        {
            try
            {
                List<StandingDto> rows = await _football.GetTableAsync();
                return Ok(rows);
            }
            catch (HttpRequestException)
            {
                return StatusCode(503, "The table is not available right now.");
            }
        }

        // GET /api/football/teams
        [HttpGet("teams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                List<TeamDto> teams = await _football.GetTeamsAsync();
                return Ok(teams);
            }
            catch (HttpRequestException)
            {
                return StatusCode(503, "The teams are not available right now.");
            }
        }
    }
}
