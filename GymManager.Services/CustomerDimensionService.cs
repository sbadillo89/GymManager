using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class CustomerDimensionService : ICustomerDimensionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDimensionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CustomerDimensionDto>>> GetAllByCustomerAsync(string customerDocument)
        {
            var dimensions = await _unitOfWork.CustomerDimensionRepository
                                        .GetByExpression(c => c.CustomerDocumentNumber == customerDocument)
                                        .OrderBy(c => c.RegistrationDate)
                                        .ToListAsync();

            return new ApiResponse<IEnumerable<CustomerDimensionDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<CustomerDimensionDto>>(dimensions)
            };
        }

        public async Task<ApiResponse<CustomerDimensionDto>> InsertAsync(CustomerDimensions customerDimension)
        {
            //validate existing customer
            var existingCustomer = await _unitOfWork.CustomerRepository
                                                    .GetByExpression(c => c.DocumentNumber == customerDimension.CustomerDocumentNumber)
                                                    .FirstOrDefaultAsync();

            if (existingCustomer == null)
            {
                return new ApiResponse<CustomerDimensionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"El usuario con número de documento [{customerDimension.CustomerDocumentNumber}], no pudo ser encontrado." }
                };
            }
            var insertedDimension = await _unitOfWork.CustomerDimensionRepository.Insert(customerDimension);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<CustomerDimensionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar registrar la información." }
                };
            }
            return new ApiResponse<CustomerDimensionDto>(_mapper.Map<CustomerDimensionDto>(insertedDimension));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _unitOfWork.CustomerDimensionRepository.SoftDelete(id);
            return await _unitOfWork.Save();
        }

    }
}