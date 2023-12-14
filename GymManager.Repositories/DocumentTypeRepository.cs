using GymManager.Entities;

namespace GymManager.Repositories
{
    public class DocumentTypeRepository : GenericRepository<DocumentTypes, Guid>
    {
        public DocumentTypeRepository(GymManagerDbContext context) : base(context)
        {

        }
    }
}