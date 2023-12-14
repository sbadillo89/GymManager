using GymManager.Entities;
using GymManager.Entities.Interfaces.Repositories;

namespace GymManager.Repositories
{
    public interface ITransactionTypeRepository : IGenericRepository<TransactionTypes, int>
    {
    }

    public class TransactionTypeRepository : GenericRepository<TransactionTypes, int>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(GymManagerDbContext context) : base(context)
        {

        }
    }
}