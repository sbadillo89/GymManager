using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class GymLocationService : IGymLocationService
    {
        public readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GymLocationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _unitOfWork.GymLocationRepository.SoftDelete(id);
            return await _unitOfWork.Save();
        }

        public async Task<ApiResponse<IEnumerable<GymLocationDto>>> GetAllAsync()
        {
            var gyms = await _unitOfWork.GymLocationRepository
                                        .GetAll(g => g.Gym)
                                        .ToListAsync();

            return new ApiResponse<IEnumerable<GymLocationDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<IEnumerable<GymLocationDto>>(gyms)
            };
        }

        public async Task<ApiResponse<GymLocationDto>> GetByIdAsync(Guid id)
        {
            var existingGym = await _unitOfWork.GymLocationRepository
                                               .GetById(id, gl => gl.Gym);
            if (existingGym == null)
            {
                return new ApiResponse<GymLocationDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró información de la sucursal." }
                };
            }

            return new ApiResponse<GymLocationDto>
            {
                Succeeded = true,
                Data = _mapper.Map<GymLocationDto>(existingGym)
            };
        }

        public async Task<ApiResponse<GymLocationDto>> InsertAsync(GymLocations gymLocationToInsert)
        {
            var existingGymLocation = _unitOfWork.GymLocationRepository.GetByExpression(gym => gym.Name == gymLocationToInsert.Name).FirstOrDefault();
            if (existingGymLocation != null)
            {
                return new ApiResponse<GymLocationDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Ya existe una Sucursal con este nombre." }
                };
            }

            //validate Gym asociated.
            var relatedGym = await _unitOfWork.GymRepository.GetById(gymLocationToInsert.GymId);
            if (relatedGym == null)
            {
                return new ApiResponse<GymLocationDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "El gimnasio asociado no existe." }
                };
            }

            gymLocationToInsert.Id = Guid.NewGuid();
            gymLocationToInsert.Active = true;

            var insertedGym = await _unitOfWork.GymLocationRepository.Insert(gymLocationToInsert);
            var inserted = await _unitOfWork.Save();

            if (!inserted)
            {
                return new ApiResponse<GymLocationDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { $"Ha ocurrido un error al intentar registrar el gymnasio {gymLocationToInsert.Name}" }
                };
            }
            return new ApiResponse<GymLocationDto>
            {
                Succeeded = true,
                Data = _mapper.Map<GymLocationDto>(insertedGym)

            };
        }

        public async Task<bool> UpdateAsync(Guid id, GymLocations gymLocationToUpdate)
        {
            var gymLocationFromDb = await _unitOfWork.GymLocationRepository.GetById(id);
            bool updated = false;
            if (gymLocationFromDb != null)
            {
                gymLocationFromDb.Name = gymLocationToUpdate.Name;
                gymLocationFromDb.Address = gymLocationToUpdate.Address;
                gymLocationFromDb.OpeningTime = gymLocationToUpdate.OpeningTime;
                gymLocationFromDb.ClosingTime = gymLocationToUpdate.ClosingTime;

                _unitOfWork.GymLocationRepository.Update(gymLocationFromDb);
                updated = await _unitOfWork.Save();
            }
            return updated;
        }
    }
}