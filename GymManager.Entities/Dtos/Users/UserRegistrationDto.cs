using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class UserRegistrationDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "El Nombre de usuario no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
        [MaxLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres.")]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}