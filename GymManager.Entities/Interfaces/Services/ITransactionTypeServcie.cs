using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface ITransactionTypeServcie
    {
        Task<ApiResponse<List<TransactionTypeDto>>> GetAll();

        Task<ApiResponse<TransactionTypeDto>> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);
    }
}