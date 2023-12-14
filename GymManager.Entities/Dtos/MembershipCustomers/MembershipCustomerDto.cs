using System.ComponentModel.DataAnnotations;

namespace GymManager.Entities.Dtos
{
    public class MembershipCustomerDto
    {
        public Guid Id { get; set; }

        public Guid MembershipTypeId { get; set; }

        public string CustomerDocumentNumber { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public decimal Amount { get; set; }

        public string UserId { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

    public class MembershipCustomerRegistrationDto
    {
        [Required]
        public Guid MembershipTypeId { get; set; }

        [Required]
        public string CustomerDocumentNumber { get; set; }
    }
}