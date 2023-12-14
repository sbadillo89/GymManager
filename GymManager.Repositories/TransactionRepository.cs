using GymManager.Entities;

namespace GymManager.Repositories
{
    public class TransactionRepository : GenericRepository<Transactions, Guid>
    {
        public TransactionRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}