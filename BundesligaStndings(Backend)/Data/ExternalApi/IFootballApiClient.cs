using BundesligaStndings_Backend_.Models;

namespace BundesligaStndings_Backend_.Data.ExternalApi
{
    public interface IFootballApiClient
    {
        Task<List<Team>> GetTableAsync();
    }
}
