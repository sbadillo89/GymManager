using AutoMapper;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class TransactionTypeServcie : ITransactionTypeServcie
    {

        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public TransactionTypeServcie(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<TransactionTypeDto>>> GetAll()
        {
            var transactionTypes = await _unitOfWork.TransactionTypeRepository
                                            .GetAll()
                                            .ToListAsync();

            return new ApiResponse<List<TransactionTypeDto>>
            {
                Data = _mapper.Map<List<TransactionTypeDto>>(transactionTypes),
                Succeeded = true
            };
        }


        public async Task<ApiResponse<TransactionTypeDto>> GetByIdAsync(int id)
        {
            var existingTransactionType = await _unitOfWork.TransactionTypeRepository.GetById(id);
            if (existingTransactionType == null)
            {
                return new ApiResponse<TransactionTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró la información del tipo de transacción." }
                };
            }

            return new ApiResponse<TransactionTypeDto>
            {
                Succeeded = true,
                Data = _mapper.Map<TransactionTypeDto>(existingTransactionType)
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.TransactionTypeRepository.SoftDelete(id);
            return await _unitOfWork.Save();
        }
    }
}