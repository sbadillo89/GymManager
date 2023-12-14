using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface ICashBoxService
    {
        Task<ApiResponse<IEnumerable<CashBoxDto>>> GetAllByDateAsync(DateTime openingDate, DateTime closingDate);

        Task<ApiResponse<IEnumerable<CashBoxDto>>> GetAllByUserAsync(string userId);

        Task<ApiResponse<CashBoxDto>> GetActiveByUserAsync(string userId);

        Task<ApiResponse<CashBoxDto>> InsertAsync(CashBox cashBox);

        Task<bool> CashCountAsync(Guid id, decimal totalCash);

        Task<bool> CloseAsync(Guid id, decimal totalCash);
    }
}