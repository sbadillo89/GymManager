using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var customers = await _unitOfWork.CustomerRepository
                                    .GetAll()
                                    .Include(c => c.DocumentType)
                                    .ToListAsync();

            return new ApiResponse<IEnumerable<CustomerDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<CustomerDto>>(customers)
            };
        }

        public async Task<ApiResponse<CustomerDto>> GetByDocumentAsync(string documentNumber)
        {
            var customer = await _unitOfWork.CustomerRepository
                                    .GetByExpression(c => c.DocumentNumber == documentNumber)
                                    .Include(x => x.DocumentType)
                                    .FirstOrDefaultAsync();

            if (customer == null)
            {
                return new ApiResponse<CustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"No se encontró información del cliente [{documentNumber}]" }
                };
            }

            return new ApiResponse<CustomerDto>
            {
                Succeeded = true,
                Data = _mapper.Map<CustomerDto>(customer)
            };
        }

        public async Task<ApiResponse<List<MembershipCustomerDto>>> GetAllMembershipsByDocumentAsync(string documentNumber)
        {
            var response = await _unitOfWork.MembershipCustomerRepository
                                             .GetByExpression(x => x.CustomerDocumentNumber == documentNumber)
                                             .ToListAsync();

            return new ApiResponse<List<MembershipCustomerDto>>
            {
                Data = _mapper.Map<List<MembershipCustomerDto>>(response),
                Succeeded = true
            };
        }

        public async Task<ApiResponse<CustomerDto>> InsertAsync(Customers customer)
        {
            var existingDocumentType = await _unitOfWork.DocumentTypeRepository.GetById(customer.DocumentTypeId);

            if (existingDocumentType == null)
            {
                return new ApiResponse<CustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "El tipo de documento asociado no existe." }
                };
            }

            var existingCustomer = _unitOfWork.CustomerRepository
                                              .GetByExpression(c => c.DocumentNumber == customer.DocumentNumber)
                                              .FirstOrDefault();
            if (existingCustomer != null)
            {
                return new ApiResponse<CustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Ya existe un cliente con este documento." }
                };
            }
            var insertedCustomer = await _unitOfWork.CustomerRepository.Insert(customer);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<CustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar registrar el cliente [{customer.DocumentNumber}]" }
                };
            }
            return new ApiResponse<CustomerDto>(_mapper.Map<CustomerDto>(insertedCustomer));
        }

        public async Task<bool> UpdateAsync(string documentNumber, Customers customer)
        {
            var customerFromDb = await _unitOfWork.CustomerRepository
                                                   .GetByExpression(C => C.DocumentNumber == documentNumber)
                                                   .FirstOrDefaultAsync();
            bool updated = false;
            if (customerFromDb != null)
            {
                customerFromDb.FirstName = customer.FirstName;
                customerFromDb.LastName = customer.LastName;
                customerFromDb.Email = customer.Email;
                customerFromDb.Genre = customer.Genre;
                customerFromDb.Observation = customer.Observation ?? "";
                customerFromDb.PhoneNumber = customer.PhoneNumber;
                customerFromDb.BirthDate = customer.BirthDate;

                _unitOfWork.CustomerRepository.Update(customerFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }

        public async Task<bool> SetActivateAsync(string documentNumber, bool activate)
        {
            var customerFromDb = await _unitOfWork.CustomerRepository
                                                   .GetByExpression(C => C.DocumentNumber == documentNumber)
                                                   .FirstOrDefaultAsync();
            bool updated = false;
            if (customerFromDb != null)
            {
                customerFromDb.Active = activate;
                _unitOfWork.CustomerRepository.Update(customerFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }

        public async Task<ApiResponse<IEnumerable<CustomerDto>>> GetBirthdaysByMonthAsync(DateTime date)
        {
            var customers = await _unitOfWork.CustomerRepository
                                   .GetByExpression(x => x.BirthDate.Month == date.Month)
                                   .ToListAsync();

            return new ApiResponse<IEnumerable<CustomerDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<CustomerDto>>(customers)
            };
        }
    }
}