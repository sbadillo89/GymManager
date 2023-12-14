using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }

        public Guid CashBoxId { get; set; }

        public int TransactionTypeId { get; set; }

        public decimal Amount { get; set; }

        public DateTime OperationDate { get; set; }

        public string Observation { get; set; }

        public string UserId { get; set; }

        public bool Activate { get; set; }
    }
    public class TransactionRegistrationDto
    {
        [Required]
        public Guid CashBoxId { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OperationDate { get; set; }

        [MaxLength(250)]
        public string Observation { get; set; }
    }

    public class TransactionUpdateDto
    {
        [Required]
        public bool Active { get; set; }

        [MaxLength(250)]
        public string Observation { get; set; }
    }
}