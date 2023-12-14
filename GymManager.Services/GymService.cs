using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class GymService : IGymService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GymService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<GymDto>>> GetAll()
        {
            var gyms = await _unitOfWork.GymRepository.GetAll().ToListAsync();

            return new ApiResponse<List<GymDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<List<GymDto>>(gyms)
            };
        }

        public async Task<ApiResponse<GymDto>> GetByIdAsync(Guid id)
        {
            var existingGym = await _unitOfWork.GymRepository.GetById(id);
            if (existingGym == null)
            {
                return new ApiResponse<GymDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró información del Gymnasio." }
                };
            }

            return new ApiResponse<GymDto>
            {
                Succeeded = true,
                Data = _mapper.Map<GymDto>(existingGym)
            };
        }

        public async Task<ApiResponse<GymDto>> InsertAsync(Gyms gymToInsert)
        {
            var existingGym = _unitOfWork.GymRepository.GetByExpression(gym => gym.Name == gymToInsert.Name).FirstOrDefault();
            if (existingGym != null)
            {
                return new ApiResponse<GymDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Ya existe un Gymnasio con este nombre." }
                };
            }

            gymToInsert.Id = Guid.NewGuid();
            gymToInsert.Active = true;

            var insertedGym = await _unitOfWork.GymRepository.Insert(gymToInsert);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<GymDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar registrar el gymnasio {gymToInsert.Name}" }
                };
            }
            return new ApiResponse<GymDto>
            {
                Succeeded = true,
                Data = _mapper.Map<GymDto>(insertedGym)

            };
        }

        public async Task<bool> UpdateAsync(Guid id, Gyms gymToUpdate)
        {
            var gymFromDb = await _unitOfWork.GymRepository.GetById(id);
            bool updated = false;
            if (gymFromDb != null)
            {
                gymFromDb.Name = gymToUpdate.Name;
                gymFromDb.Address = gymToUpdate.Address;
                gymFromDb.Email = gymToUpdate.Email;
                gymFromDb.FacebookPage = gymToUpdate.FacebookPage;
                gymFromDb.InstagramPage = gymToUpdate.InstagramPage;
                gymFromDb.PhoneNumber = gymToUpdate.PhoneNumber;

                _unitOfWork.GymRepository.Update(gymFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _unitOfWork.GymRepository.SoftDelete(id);
            return await _unitOfWork.Save();
        }
    }
}