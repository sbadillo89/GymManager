using System.Security.Claims;
using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymsController : Controller
    {
        private readonly IGymService _gymService;
        public readonly IMapper _mapper;

        public GymsController(IGymService gymService, IMapper mapper)
        {
            _gymService = gymService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResponse<List<GymDto>>> GetAll()
        {
            var gyms = await _gymService.GetAll();

            return gyms;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<GymDto>> GetById(Guid id)
        {
            return await _gymService.GetByIdAsync(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GymRegistrationDto gymRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<GymDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = User.FindFirst("id")?.Value;

            var gymMapped = _mapper.Map<Gyms>(gymRegistration);
            var response = await _gymService.InsertAsync(gymMapped);

            return StatusCode(response!.Succeeded
                             ? StatusCodes.Status201Created
                             : StatusCodes.Status400BadRequest, response);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GymUpdateDto gymToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<GymDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }
            var gymMapped = _mapper.Map<Gyms>(gymToUpdate);
            var response = await _gymService.UpdateAsync(id, gymMapped);

            return response
                        ? NoContent()
                        : BadRequest(new ApiResponse<GymDto>
                        {
                            Succeeded = false,
                            Errors = new List<string> { $"No se ha podido actualizar el registro." }
                        });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool response = await _gymService.DeleteAsync(id);

            return response
                        ? NoContent()
                        : BadRequest(new ApiResponse<GymDto>
                        {
                            Succeeded = false,
                            Errors = new List<string> { $"No se ha podido eliminar el registro." }
                        });
        }
    }
}

