using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface IMembershipTypeService
    {
        Task<ApiResponse<IEnumerable<MembershipTypeDto>>> GetAllAsync();

        Task<ApiResponse<MembershipTypeDto>> GetByIdAsync(Guid id);

        Task<ApiResponse<MembershipTypeDto>> InsertAsync(MembershipTypes membershipTypes);

        Task<bool> UpdateAsync(Guid id, MembershipTypes membershipTypes);

        Task<bool> DeleteAsync(Guid id);
    }
}