using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class CustomerChanges : EntityBase
    {
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ChangeDate { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Customers Customer { get; set; }

        public CustomerChanges()
        {

        }

        public CustomerChanges(Guid _id, string _docNumber, bool _isActive, string _userId, DateTime _changeDate)
        {
            Id = _id;
            DocumentNumber = _docNumber;
            Active = _isActive;
            UserId = _userId;
            ChangeDate = _changeDate;
        }
    }
}