using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ApiResponse<IEnumerable<CustomerDto>>> GetAllAsync();

        Task<ApiResponse<IEnumerable<CustomerDto>>> GetBirthdaysByMonthAsync(DateTime date);

        Task<ApiResponse<CustomerDto>> GetByDocumentAsync(string documentNumber);

        Task<ApiResponse<List<MembershipCustomerDto>>> GetAllMembershipsByDocumentAsync(string documentNumber);

        Task<ApiResponse<CustomerDto>> InsertAsync(Customers customer);

        Task<bool> UpdateAsync(string documentNumber, Customers customer);

        Task<bool> SetActivateAsync(string documentNumber, bool activate);
    }
}