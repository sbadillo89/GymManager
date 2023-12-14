using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class CustomerDto
    {
        public string DocumentNumber { get; set; }

        public Guid DocumentTypeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string Genre { get; set; }

        public DateTime LastAccess { get; set; }

        public string UserId { get; set; }

        public string Observation { get; set; }

        public bool Activate { get; set; }
    }

    public class CustomerRegistrationDto
    {
        [Required]
        public Guid DocumentTypeId { get; set; }

        [Required]
        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(20)]
        [RegularExpression("Masculino|Femenino|Otro", ErrorMessage = "Genero inválido. Valores permitidos: Masculino, Femenino, Otro")]
        public string Genre { get; set; }

        [MaxLength(450)]
        public string? Observation { get; set; }
    }
}