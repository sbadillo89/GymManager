using GymManager.Entities;
using GymManager.Entities.Interfaces.Repositories;

namespace GymManager.Repositories
{
    public class GymRepository : GenericRepository<Gyms, Guid>, IGymRepository
    {
        public GymRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}