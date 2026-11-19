using Bundesliga_Standings_App.Models;
using BundesligaStndings_Backend_.Data.Repositories;
using BundesligaStndings_Backend_.Dto;
using BundesligaStndings_Backend_.Dto.Auth;
using Microsoft.AspNetCore.Identity;

namespace BundesligaStndings_Backend_.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

        public AuthService(IUserRepository users)
        {
            _users = users;
        }

        public async Task<bool> RegisterAsync(RegisterRequestDto dto)
        {
            string email = dto.Email.Trim().ToLower();

            // 1. The email must be free
            if (await _users.EmailExistsAsync(email))
            {
                return false;
            }

            // 2. Form data → User (the password is saved only as a hash)
            User user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = email,
                FavTeamId = dto.FavTeamId
            };
            user.PasswordHash = _hasher.HashPassword(user, dto.Password);

            // 3. Save it
            await _users.AddAsync(user);
            return true;
        }

        public async Task<UserDto?> LoginAsync(LoginRequestDto dto)
        {
            string email = dto.Email.Trim().ToLower();

            // 1. Find the user
            User? user = await _users.GetByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            // 2. Check the password against the saved hash
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // 3. User → UserDto (no password hash)
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                FavTeamId = user.FavTeamId
            };
        }
    }
}
