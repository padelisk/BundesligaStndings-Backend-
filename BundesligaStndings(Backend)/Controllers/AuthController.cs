using BundesligaStndings_Backend_.Dto;
using BundesligaStndings_Backend_.Dto.Auth;
using BundesligaStndings_Backend_.Services;
using Microsoft.AspNetCore.Mvc;

namespace BundesligaStndings_Backend_.Controllers
{
   
    
        [ApiController]
        [Route("api/auth")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _auth;

            public AuthController(IAuthService auth)
            {
                _auth = auth;
            }

            // POST /api/auth/register
            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterRequestDto dto)
            {
                bool created = await _auth.RegisterAsync(dto);
                if (!created)
                {
                    return BadRequest("Email already exists.");
                }

                return Ok("Account created.");
            }

            // POST /api/auth/login
            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginRequestDto dto)
            {
                UserDto? user = await _auth.LoginAsync(dto);
                if (user == null)
                {
                    return Unauthorized("Invalid email or password.");
                }

                return Ok(user);
            }
        }
    }
