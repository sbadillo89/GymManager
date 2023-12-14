using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public record DocumentTypeDto
    {

        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
    }
}

