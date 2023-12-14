using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class CustomerDimensionDto
    {
        public Guid Id { get; set; }

        public string CustomerDocumentNumber { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double BodyFatPercentage { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

    public class CustomerDimensionRegistrationDto
    { 
        [Required]
        public string CustomerDocumentNumber { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Weight { get; set; }

        public double BodyFatPercentage { get; set; }
    }
}