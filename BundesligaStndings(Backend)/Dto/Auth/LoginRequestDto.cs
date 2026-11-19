using System.ComponentModel.DataAnnotations;

namespace BundesligaStndings_Backend_.Dto.Auth
{
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
