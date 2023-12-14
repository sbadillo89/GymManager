using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public record TransactionTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovementType { get; set; }
    }

    public record TransactionTypeRegistrationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("1|-1|0", ErrorMessage = "Tipo de movimiento inválido. Valores permitidos: Ingreso:1, Neutro:0, Egreso:-1")]
        public int MovementType { get; set; }
    }
}