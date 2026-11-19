using System.ComponentModel.DataAnnotations;

namespace BundesligaStndings_Backend_.Dto.Auth
{
    public class RegisterRequestDto
    {
        [Required, MaxLength(45)]
        public string FirstName { get; set; } = "";

        [Required, MaxLength(45)]
        public string LastName { get; set; } = "";

        [Required, EmailAddress, MaxLength(45)]
        public string Email { get; set; } = "";

        [Required, MinLength(6)]
        public string Password { get; set; } = "";

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = "";

        [Range(1, int.MaxValue, ErrorMessage = "Please choose a team.")]
        public int FavTeamId { get; set; }
    }
}
