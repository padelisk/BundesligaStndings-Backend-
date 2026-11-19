using Bundesliga_Standings_App.Models;

namespace BundesligaStndings_Backend_.Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
