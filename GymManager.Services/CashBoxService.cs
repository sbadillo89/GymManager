using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class CashBoxService : ICashBoxService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CashBoxService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<CashBoxDto>> GetActiveByUserAsync(string userId)
        {
            var activeCash = await _unitOfWork.CashBoxRepository
                                        .GetByExpression(c => c.UserId == userId && c.Active)
                                        .Include(c => c.Transactions)
                                        .FirstOrDefaultAsync();

            if (activeCash == null)
            {
                return new ApiResponse<CashBoxDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"No se encontró una caja activa para este cliente" }
                };
            }

            return new ApiResponse<CashBoxDto>
            {
                Succeeded = true,
                Data = _mapper.Map<CashBoxDto>(activeCash)
            };
        }

        public async Task<ApiResponse<IEnumerable<CashBoxDto>>> GetAllByDateAsync(DateTime openingDate, DateTime closingDate)
        {
            var cashBoxes = await _unitOfWork.CashBoxRepository
                                        .GetByExpression(c => c.OpeningDate >= openingDate && c.ClosingDate <= closingDate)
                                        .ToListAsync();

            return new ApiResponse<IEnumerable<CashBoxDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<CashBoxDto>>(cashBoxes)
            };
        }

        public async Task<ApiResponse<IEnumerable<CashBoxDto>>> GetAllByUserAsync(string userId)
        {
            var cashBoxes = await _unitOfWork.CashBoxRepository
                                    .GetByExpression(c => c.UserId == userId)
                                    .ToListAsync();

            return new ApiResponse<IEnumerable<CashBoxDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<CashBoxDto>>(cashBoxes)
            };
        }

        public async Task<ApiResponse<CashBoxDto>> InsertAsync(CashBox cashBox)
        {
            var existingActiveCashBox = GetCashBoxActivate(cashBox.UserId);
            if (existingActiveCashBox != null)
            {
                return new ApiResponse<CashBoxDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Existe una caja activa para este usuario, cierre esta si desea abrir una nueva." }
                };
            }

            //validate GymLocation
            var existingGymLocation = await _unitOfWork.GymLocationRepository.GetById(cashBox.GymLocationId);
            if (existingGymLocation == null)
            {
                return new ApiResponse<CashBoxDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró información de la sucursal." }
                };
            }
            cashBox.ClosingDate = DateTime.MinValue;
            var insertedCashBox = await _unitOfWork.CashBoxRepository.Insert(cashBox);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<CashBoxDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar abrir la caja." }
                };
            }
            return new ApiResponse<CashBoxDto>(_mapper.Map<CashBoxDto>(insertedCashBox));

        }

        public async Task<bool> CashCountAsync(Guid id, decimal totalCash)
        {
            var totalCashBox = GetTotalCashBoxSystem(id);

            return (totalCash == totalCashBox);
        }

        public async Task<bool> CloseAsync(Guid cashBoxId, decimal totalCash)
        {
            var cashBox = await _unitOfWork.CashBoxRepository
                                           .GetByExpression(c => c.Id == cashBoxId && c.Active)
                                           .FirstOrDefaultAsync();

            bool updated = false;
            if (cashBox != null)
            {
                cashBox.ClosingDate = DateTime.UtcNow;
                cashBox.FinalUserBalance = totalCash;
                cashBox.FinalSystemBalance = GetTotalCashBoxSystem(cashBoxId);
                cashBox.Discrepancy = cashBox.FinalUserBalance - cashBox.FinalSystemBalance;
                cashBox.Active = false;
                _unitOfWork.CashBoxRepository.Update(cashBox);
                updated = await _unitOfWork.Save();
            }

            return updated;
        }

        private CashBox? GetCashBoxActivate(string userId)
        {
            var activateCashBox = _unitOfWork.CashBoxRepository
                                                   .GetByExpression(c => c.UserId == userId && c.Active)
                                                   .Include(c => c.Transactions)
                                                   .FirstOrDefault();
            return activateCashBox;
        }

        private decimal GetTotalCashBoxSystem(Guid cashBoxId)
        {

            //usar TransactionRepository
            var cashBox = _unitOfWork.CashBoxRepository
                                                   .GetByExpression(c => c.Id == cashBoxId && c.Active)
                                                   .Include(c => c.Transactions)
                                                   .ThenInclude(trx => trx.TransactionType)
                                                   .FirstOrDefault();

            if (cashBox == null)
                return 0;

            var totalTransactionsAmount = cashBox!.Transactions
                                                  .ToList()
                                                  .Sum(t => (t.Amount * t.TransactionType.MovementType));

            var totalCashBox = cashBox.InitialBalance + totalTransactionsAmount;

            return totalCashBox;
        }
    }
}