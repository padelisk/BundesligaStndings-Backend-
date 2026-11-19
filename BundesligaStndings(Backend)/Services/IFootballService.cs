using BundesligaStndings_Backend_.Dto;

namespace BundesligaStndings_Backend_.Services
{
    public interface IFootballService
    {
        Task<List<StandingDto>> GetTableAsync();
        Task<List<TeamDto>> GetTeamsAsync();
    }
}
