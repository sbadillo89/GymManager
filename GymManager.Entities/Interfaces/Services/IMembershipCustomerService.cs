using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface IMembershipCustomerService
    {
        Task<ApiResponse<List<MembershipCustomerDto>>> GetAll();

        Task<ApiResponse<MembershipCustomerDto>> GetByIdAsync(Guid id);

        Task<ApiResponse<MembershipCustomerDto>> InsertAsync(MembershipCustomers membershipCustomers);

        Task<bool> SetActivateAsync(Guid id, bool active);

        Task<bool> DeleteAsync(Guid id);

        Task<bool> InactivateAllExpiredAsync();
    }
}