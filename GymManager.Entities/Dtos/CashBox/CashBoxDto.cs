using System;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class CashBoxDto
    {
        public Guid Id { get; set; }

        public Guid GymLocationId { get; set; }

        public decimal InitialBalance { get; set; }

        public decimal FinalBalance { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public string UserId { get; set; }

        public IEnumerable<Transactions> Transactions { get; set; }
    }

    public class CashBoxRegistrationDto
    {
        [Required]
        public Guid GymLocationId { get; set; }

        public decimal InitialBalance { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OpeningDate { get; set; }

    }
}