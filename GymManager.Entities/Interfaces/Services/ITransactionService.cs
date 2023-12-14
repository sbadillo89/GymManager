using GymManager.Entities.Dtos;
using GymManager.Entities.Responses;

namespace GymManager.Entities.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<ApiResponse<List<TransactionDto>>> GetAllByCashBox(Guid cashBoxId);

        Task<ApiResponse<TransactionDto>> InsertAsync(Transactions transaction);

        Task<bool> SetActivateAsync(Guid transactionId, TransactionUpdateDto transactionUpdateDto);
    }
}