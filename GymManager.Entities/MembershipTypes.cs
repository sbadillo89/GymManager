using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class MembershipTypes : EntityBase
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public int DurationDays { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InitialDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FinalDate { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public MembershipTypes()
        {

        }

        public MembershipTypes(Guid _id, string _description, int _durationDays, decimal _price, DateTime _initialDate, DateTime _finalDate, bool _isActive, string _userId)
        {
            Id = _id;
            Description = _description;
            DurationDays = _durationDays;
            Price = _price;
            InitialDate = _initialDate;
            FinalDate = _finalDate;
            Active = _isActive;
            UserId = _userId;
        }
    }
}

