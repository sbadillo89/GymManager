using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface IGymService
    {
        Task<ApiResponse<List<GymDto>>> GetAll();

        Task<ApiResponse<GymDto>> GetByIdAsync(Guid id);

        Task<ApiResponse<GymDto>> InsertAsync(Gyms gymToInsert);

        Task<bool> UpdateAsync(Guid id, Gyms gymToUpdate);

        Task<bool> DeleteAsync(Guid id);
    }
}