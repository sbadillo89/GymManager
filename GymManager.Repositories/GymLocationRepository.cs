using GymManager.Entities;

namespace GymManager.Repositories
{
    public class GymLocationRepository : GenericRepository<GymLocations, Guid>
    {
        public GymLocationRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}