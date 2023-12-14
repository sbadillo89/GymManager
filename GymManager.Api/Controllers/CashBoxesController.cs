using AutoMapper;
using GymManager.Entities;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashBoxesController : ControllerBase
    {
        private readonly ICashBoxService _cashBoxService;
        public readonly IMapper _mapper;

        public CashBoxesController(ICashBoxService cashBoxService, IMapper mapper)
        {
            _mapper = mapper;
            _cashBoxService = cashBoxService;
        }

        [HttpGet("get-all-by-user")]
        public async Task<ApiResponse<IEnumerable<CashBoxDto>>> GetByUser(string userId)
        {
            return await _cashBoxService.GetAllByUserAsync(userId);
        }

        [HttpGet("get-all-by-dates")]
        public async Task<ApiResponse<IEnumerable<CashBoxDto>>> GetByDates(DateTime openingDate, DateTime closingDate)
        {
            return await _cashBoxService.GetAllByDateAsync(openingDate, closingDate);
        }

        [HttpGet("get-active-by-user")]
        public async Task<IActionResult> GetActiveByUser(string userId)
        {
            var response = await _cashBoxService.GetActiveByUserAsync(userId);

            return StatusCode(response.Succeeded ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CashBoxRegistrationDto cashBoxRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<CashBoxDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }
            var entityMapped = _mapper.Map<CashBox>(cashBoxRegistration);
            entityMapped.UserId = User.FindFirst("id")?.Value!;

            var response = await _cashBoxService.InsertAsync(entityMapped);

            return StatusCode(response!.Succeeded
                            ? StatusCodes.Status201Created
                            : StatusCodes.Status400BadRequest, response);

        }

        [HttpPut("close")]
        public async Task<IActionResult> Put(Guid id, decimal totalCash)
        {
            var response = await _cashBoxService.CloseAsync(id, totalCash);

            return response
                        ? NoContent()
                        : BadRequest(new ApiResponse<CashBoxDto>
                        {
                            Succeeded = false,
                            Errors = new List<string> { $"No se ha podido cerrar la caja." }
                        });
        }
    }
}

