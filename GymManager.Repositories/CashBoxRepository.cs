using GymManager.Entities;

namespace GymManager.Repositories
{
    public class CashBoxRepository : GenericRepository<CashBox, Guid>
    {
        public CashBoxRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}