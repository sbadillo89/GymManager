using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class MembershipTypeService : IMembershipTypeService
    {

        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public MembershipTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _unitOfWork.MembershipTypeRepository.SoftDelete(id);
            return await _unitOfWork.Save();
        }

        public async Task<ApiResponse<IEnumerable<MembershipTypeDto>>> GetAllAsync()
        {
            var response = await _unitOfWork.MembershipTypeRepository
                                      .GetAll()
                                      .Include(x => x.User)
                                      .Where(x => x.FinalDate >= DateTime.UtcNow || x.FinalDate == DateTime.MinValue)
                                      .ToListAsync();

            return new ApiResponse<IEnumerable<MembershipTypeDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<MembershipTypeDto>>(response)
            };
        }

        public async Task<ApiResponse<MembershipTypeDto>> GetByIdAsync(Guid id)
        {
            var response = await _unitOfWork.MembershipTypeRepository
                                            .GetByExpression(x => x.Id == id && x.FinalDate >= DateTime.UtcNow)
                                            .FirstOrDefaultAsync();

            if (response == null)
            {
                return new ApiResponse<MembershipTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró información del tipo de membresía." }
                };
            }

            return new ApiResponse<MembershipTypeDto>
            {
                Succeeded = true,
                Data = _mapper.Map<MembershipTypeDto>(response)
            };
        }

        public async Task<ApiResponse<MembershipTypeDto>> InsertAsync(MembershipTypes membershipType)
        {
            var existingMembershipType = _unitOfWork.MembershipTypeRepository.GetByExpression(gym => gym.Description == membershipType.Description).FirstOrDefault();
            if (existingMembershipType != null)
            {
                return new ApiResponse<MembershipTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Ya existe un tipo de membresía con este nombre." }
                };
            }

            membershipType.Id = Guid.NewGuid();
            membershipType.Active = true;

            var insertedMembershipType = await _unitOfWork.MembershipTypeRepository.Insert(membershipType);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<MembershipTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar registrar el tipo de membresía [{membershipType.Description}]" }
                };
            }
            return new ApiResponse<MembershipTypeDto>
            {
                Succeeded = true,
                Data = _mapper.Map<MembershipTypeDto>(insertedMembershipType)

            };
        }

        public async Task<bool> UpdateAsync(Guid id, MembershipTypes membershipTypes)
        {
            var membershipTypeFromDb = await _unitOfWork.MembershipTypeRepository.GetById(id);
            bool updated = false;
            if (membershipTypeFromDb != null)
            {
                membershipTypeFromDb.Description = membershipTypes.Description;
                membershipTypeFromDb.DurationDays = membershipTypes.DurationDays;
                membershipTypeFromDb.FinalDate = membershipTypes.FinalDate;
                membershipTypeFromDb.InitialDate = membershipTypes.InitialDate;
                membershipTypeFromDb.Price = membershipTypes.Price;

                _unitOfWork.MembershipTypeRepository.Update(membershipTypeFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }
    }
}