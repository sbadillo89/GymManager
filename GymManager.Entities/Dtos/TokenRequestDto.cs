using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public record TokenRequestDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}

