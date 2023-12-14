using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface IDocumentTypeService
    {

        Task<ApiResponse<IEnumerable<DocumentTypeDto>>> GetAllAsync();

        Task<ApiResponse<DocumentTypeDto>> GetByIdAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);

    }
}