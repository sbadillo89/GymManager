using GymManager.Entities;

namespace GymManager.Repositories
{
    public class MembershipCustomerRepository : GenericRepository<MembershipCustomers, Guid>
    {
        public MembershipCustomerRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}