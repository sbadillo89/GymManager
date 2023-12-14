using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class Customers : EntityBase
    {
        public Guid DocumentTypeId { get; set; }
        [Key]
        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [MaxLength(20)]
        public string Genre { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastAccess { get; set; }

        public string UserId { get; set; }

        public string Observation { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual DocumentTypes DocumentType { get; set; }

        public Customers()
        {
        }
    }
}