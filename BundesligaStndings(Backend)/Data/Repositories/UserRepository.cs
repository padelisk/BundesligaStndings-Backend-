using Bundesliga_Standings_App.Models;
using MySqlConnector;

namespace BundesligaStndings_Backend_.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Default")!;
        }

        // Is there already a user with this email?
        public async Task<bool> EmailExistsAsync(string email)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE email = @email", conn);
            cmd.Parameters.AddWithValue("@email", email);

            int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return count > 0;
        }

        // Save a new user
        public async Task AddAsync(User user)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(
                "INSERT INTO users (first_name, last_name, email, password_hash, fav_team_id) " +
                "VALUES (@firstName, @lastName, @email, @passwordHash, @favTeamId)", conn);
            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.LastName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@favTeamId", user.FavTeamId);

            await cmd.ExecuteNonQueryAsync();
        }

        // Find a user by email (null if not found)
        public async Task<User?> GetByEmailAsync(string email)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            using var cmd = new MySqlCommand(
                "SELECT id, first_name, last_name, email, password_hash, fav_team_id " +
                "FROM users WHERE email = @email", conn);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = await cmd.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
            {
                return null;
            }

            return new User
            {
                Id = reader.GetInt32("id"),
                FirstName = reader.GetString("first_name"),
                LastName = reader.GetString("last_name"),
                Email = reader.GetString("email"),
                PasswordHash = reader.GetString("password_hash"),
                FavTeamId = reader.GetInt32("fav_team_id")
            };
        }
    }
}
