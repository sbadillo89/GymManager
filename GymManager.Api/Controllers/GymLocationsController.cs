using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymLocationsController : ControllerBase
    {
        IGymLocationService _gymLocationService;
        IMapper _mapper;

        public GymLocationsController(IGymLocationService gymLocationService, IMapper mapper)
        {
            _gymLocationService = gymLocationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<GymLocationDto>>> GetAll()
        {
            return await _gymLocationService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _gymLocationService.GetByIdAsync(id);

            return response.Succeeded
                    ? Ok(response)
                    : BadRequest(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GymLocationRegistrationDto gymLocationRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<GymLocationDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }
            var userId = User.FindFirst("id")?.Value;

            var gymLocationMapped = _mapper.Map<GymLocations>(gymLocationRegistration);
            gymLocationMapped.UserId = userId;

            var response = await _gymLocationService.InsertAsync(gymLocationMapped);

            return StatusCode(response!.Succeeded
                                ? StatusCodes.Status201Created
                                : StatusCodes.Status400BadRequest, response);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GymLocationUpdateDto gymLocationUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<GymLocationDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var gymLocationMapped = _mapper.Map<GymLocations>(gymLocationUpdateDto);
            var response = await _gymLocationService.UpdateAsync(id, gymLocationMapped);

            return response
                      ? NoContent()
                      : BadRequest(new ApiResponse<GymLocationDto>
                      {
                          Succeeded = false,
                          Errors = new List<string> { $"No se ha podido actualizar el registro." }
                      });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool response = await _gymLocationService.DeleteAsync(id);

            return response
                        ? NoContent()
                        : BadRequest(new ApiResponse<GymLocationDto>
                        {
                            Succeeded = false,
                            Errors = new List<string> { $"No se ha podido eliminar el registro." }
                        });
        }
    }
}

