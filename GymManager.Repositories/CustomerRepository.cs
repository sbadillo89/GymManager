using GymManager.Entities;

namespace GymManager.Repositories
{
    public class CustomerRepository : GenericRepository<Customers, Guid>
    {
        public CustomerRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}