using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface IGymLocationService
    {
        Task<ApiResponse<IEnumerable<GymLocationDto>>> GetAllAsync();

        Task<ApiResponse<GymLocationDto>> GetByIdAsync(Guid id);

        Task<ApiResponse<GymLocationDto>> InsertAsync(GymLocations gymLocationToInsert);

        Task<bool> UpdateAsync(Guid id, GymLocations gymLocationToUpdate);

        Task<bool> DeleteAsync(Guid id);
    }
}