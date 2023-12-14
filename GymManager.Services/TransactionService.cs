using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<TransactionDto>>> GetAllByCashBox(Guid cashBoxId)
        {
            var cashBoxes = await _unitOfWork.TransactionRepository
                                        .GetByExpression(c => c.CashBoxId == cashBoxId)
                                        .ToListAsync();

            return new ApiResponse<List<TransactionDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<List<TransactionDto>>(cashBoxes)
            };
        }

        public async Task<ApiResponse<TransactionDto>> InsertAsync(Transactions transaction)
        {
            var existingActiveCashBox = await _unitOfWork.CashBoxRepository
                                                         .GetByExpression(c => c.Id == transaction.CashBoxId & c.Active)
                                                         .FirstOrDefaultAsync();
            if (existingActiveCashBox == null)
            {
                return new ApiResponse<TransactionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró una caja activa." }
                };
            }

            //validate Transaction type
            var existingTransactionType = await _unitOfWork.TransactionTypeRepository.GetById(transaction.TransactionTypeId);
            if (existingTransactionType == null)
            {
                return new ApiResponse<TransactionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró la información del tipo de transacción." }
                };
            }

            var insertedTransaction = await _unitOfWork.TransactionRepository.Insert(transaction);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<TransactionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar registrar la transacción." }
                };
            }
            return new ApiResponse<TransactionDto>(_mapper.Map<TransactionDto>(insertedTransaction));
        }

        public async Task<bool> SetActivateAsync(Guid transactionId, TransactionUpdateDto transactionUpdateDto)
        {
            var transactionFromDb = await _unitOfWork.TransactionRepository
                                                     .GetByExpression(C => C.Id == transactionId)
                                                     .FirstOrDefaultAsync();
            bool updated = false;
            if (transactionFromDb != null)
            {
                transactionFromDb.Active = transactionUpdateDto.Active;
                transactionFromDb.Observation = transactionUpdateDto.Observation ?? transactionFromDb.Observation;

                _unitOfWork.TransactionRepository.Update(transactionFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }
    }
}

