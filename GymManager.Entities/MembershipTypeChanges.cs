using Microsoft.AspNetCore.Identity;

namespace GymManager.Entities
{
    public class MembershipTypeChanges : EntityBase
    {
        public Guid Id { get; set; }
        public Guid MembershipTypeId { get; set; }
        public string UserId { get; set; }
        public DateTime ChangeDate { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual MembershipTypes MembershipType { get; set; }

        public MembershipTypeChanges()
        {

        }

        public MembershipTypeChanges(Guid _id, Guid _membershipTypeId, bool _isActive, string _userId, DateTime _changeDate)
        {
            Id = _id;
            MembershipTypeId = _membershipTypeId;
            Active = _isActive;
            UserId = _userId;
            ChangeDate = _changeDate;
        }
    }
}
