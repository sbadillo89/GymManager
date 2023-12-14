using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public record UserLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}