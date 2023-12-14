using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class MembershipCustomerService : IMembershipCustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipCustomerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<MembershipCustomerDto>>> GetAll()
        {
            var response = await _unitOfWork.MembershipCustomerRepository
                                            .GetAll()
                                            .ToListAsync();

            return new ApiResponse<List<MembershipCustomerDto>>
            {
                Data = _mapper.Map<List<MembershipCustomerDto>>(response),
                Succeeded = true
            };
        }
         
        public async Task<ApiResponse<MembershipCustomerDto>> GetByIdAsync(Guid id)
        {
            var response = await _unitOfWork.MembershipTypeRepository
                                             .GetByExpression(x => x.Id == id && x.FinalDate >= DateTime.UtcNow)
                                             .FirstOrDefaultAsync();

            if (response == null)
            {
                return new ApiResponse<MembershipCustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró información de la membresía." }
                };
            }

            return new ApiResponse<MembershipCustomerDto>
            {
                Succeeded = true,
                Data = _mapper.Map<MembershipCustomerDto>(response)
            };
        }

        public async Task<ApiResponse<MembershipCustomerDto>> InsertAsync(MembershipCustomers membershipCustomer)
        {
            // Get the membership type information
            var membershipType = await _unitOfWork.MembershipTypeRepository.GetById(membershipCustomer.MembershipTypeId);

            if (membershipType == null)
            {
                return new ApiResponse<MembershipCustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Tipo de membresía inválida." }
                };
            }

            //validate existing customer
            var existingCustomer = await _unitOfWork.CustomerRepository
                                                    .GetByExpression(c => c.DocumentNumber == membershipCustomer.CustomerDocumentNumber)
                                                    .FirstOrDefaultAsync();

            if (existingCustomer == null)
            {
                return new ApiResponse<MembershipCustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"El usuario con número de documento [{membershipCustomer.CustomerDocumentNumber}], no pudo ser encontrado." }
                };
            }

            //validate existing membership customer
            var existingMembershipCustomer = _unitOfWork.MembershipCustomerRepository
                                                    .GetByExpression(x => x.CustomerDocumentNumber == membershipCustomer.CustomerDocumentNumber
                                                                        && x.FinalDate > membershipType!.InitialDate
                                                                        && x.Active)
                                                    .FirstOrDefault();

            if (existingMembershipCustomer != null)
            {
                return new ApiResponse<MembershipCustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ya existe un membresía para este cliente y está activa hasta el {existingMembershipCustomer.FinalDate.ToString("dd-MM-yyyy")}" }
                };
            }

            membershipCustomer.Id = Guid.NewGuid();
            membershipCustomer.Amount = membershipType!.Price;
            membershipCustomer.InitialDate = DateTime.UtcNow;
            membershipCustomer.FinalDate = DateTime.UtcNow.AddDays(membershipType.DurationDays);
            membershipCustomer.Active = true;

            var insertedMembershipCustomer = await _unitOfWork.MembershipCustomerRepository.Insert(membershipCustomer);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<MembershipCustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar adquirir la membresía." }
                };
            }
            return new ApiResponse<MembershipCustomerDto>
            {
                Succeeded = true,
                Data = _mapper.Map<MembershipCustomerDto>(insertedMembershipCustomer)

            };
        }

        public async Task<bool> SetActivateAsync(Guid id, bool active = false)
        {
            var membershipCustomerFromDb = await _unitOfWork.MembershipCustomerRepository.GetById(id);
            bool updated = false;
            if (membershipCustomerFromDb != null)
            {
                membershipCustomerFromDb.Active = active;

                _unitOfWork.MembershipCustomerRepository.Update(membershipCustomerFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _unitOfWork.MembershipCustomerRepository.SoftDelete(id);
            return await _unitOfWork.Save();
        }

        public async Task<bool> InactivateAllExpiredAsync()
        {
            var membershipsExpiredFromDb = await _unitOfWork.MembershipCustomerRepository
                                                         .GetByExpression(x => x.FinalDate < DateTime.UtcNow)
                                                         .ToListAsync();
            bool updated = false;
            if (membershipsExpiredFromDb != null)
            {
                foreach (var membership in membershipsExpiredFromDb)
                {
                    membership.Active = false;
                    _unitOfWork.MembershipCustomerRepository.Update(membership);
                }
                updated = await _unitOfWork.Save();
            }
            return updated;
        }
    }
}