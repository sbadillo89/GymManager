using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface ICustomerDimensionService
    {
        Task<ApiResponse<IEnumerable<CustomerDimensionDto>>> GetAllByCustomerAsync(string customerDocument);

        Task<ApiResponse<CustomerDimensionDto>> InsertAsync(CustomerDimensions customerDimension);

        Task<bool> DeleteAsync(Guid id);
    }
}