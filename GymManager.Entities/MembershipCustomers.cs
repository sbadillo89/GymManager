using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class MembershipCustomers : EntityBase
    {
        [Column(Order = 1)]
        public Guid Id { get; set; }

        [Column(Order = 2)]
        public Guid MembershipTypeId { get; set; }

        [MaxLength(20)]
        [ForeignKey("Customers")]
        [Column(Order = 3)]
        public string CustomerDocumentNumber { get; set; }

        [Column(Order = 4)]
        [DataType(DataType.DateTime)]
        public DateTime InitialDate { get; set; }

        [Column(Order = 5)]
        [DataType(DataType.DateTime)]
        public DateTime FinalDate { get; set; }

        [Column(Order = 6)]
        public decimal Amount { get; set; }

        [Column(Order = 7)]
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual MembershipTypes MembershipType { get; set; }

        public MembershipCustomers()
        {

        }

        public MembershipCustomers(Guid _id, Guid _membershipTypeId, string _documentNumber, DateTime _initialDate, DateTime _finalDate, decimal _amount, string _userId, DateTime _registrationDate)
        {
            Id = _id;
            MembershipTypeId = _membershipTypeId;
            CustomerDocumentNumber = _documentNumber;
            InitialDate = _initialDate;
            FinalDate = _finalDate;
            Amount = _amount;
            UserId = _userId;
            RegistrationDate = _registrationDate;
        }
    }
}