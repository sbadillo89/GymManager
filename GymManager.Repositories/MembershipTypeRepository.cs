using GymManager.Entities;

namespace GymManager.Repositories
{
    public class MembershipTypeRepository : GenericRepository<MembershipTypes, Guid>
    {
        public MembershipTypeRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}