using System;
using GymManager.Entities;

namespace GymManager.Repositories
{
    public class CustomerDimensionRepository : GenericRepository<CustomerDimensions, Guid>
    {
        public CustomerDimensionRepository(GymManagerDbContext context) : base(context)
        {
        }
    }
}