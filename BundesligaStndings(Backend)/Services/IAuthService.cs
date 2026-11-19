using BundesligaStndings_Backend_.Dto;
using BundesligaStndings_Backend_.Dto.Auth;

namespace BundesligaStndings_Backend_.Services
{
    public interface IAuthService
    {
        // true = account created, false = email already exists
        Task<bool> RegisterAsync(RegisterRequestDto dto);

        // the user if email + password are correct, otherwise null
        Task<UserDto?> LoginAsync(LoginRequestDto dto);

    }
}