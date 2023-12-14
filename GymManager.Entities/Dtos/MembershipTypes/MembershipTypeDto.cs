using System;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class MembershipTypeDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public int DurationDays { get; set; }

        public decimal Price { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public string UserId { get; set; }
    }

    public class MembershipTypeRegistrationDto
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int DurationDays { get; set; }

        [Required]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime InitialDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinalDate { get; set; }
    }

    public class MembershipTypUpdateDto
    {
        [MaxLength(100)]
        public string Description { get; set; }

        public int DurationDays { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime InitialDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime FinalDate { get; set; }
    }
}