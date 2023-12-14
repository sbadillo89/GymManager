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
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _mapper = mapper;
            _transactionService = transactionService;
        }

        [HttpGet("get-all-by-cashbox")]
        public async Task<ApiResponse<List<TransactionDto>>> GetAllByCashBox(Guid cashBoxId)
        {
            return await _transactionService.GetAllByCashBox(cashBoxId);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionRegistrationDto transactionRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<TransactionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }
            var entityMapped = _mapper.Map<Transactions>(transactionRegistration);
            entityMapped.UserId = User.FindFirst("id")?.Value!;

            var response = await _transactionService.InsertAsync(entityMapped);

            return StatusCode(response!.Succeeded
                            ? StatusCodes.Status201Created
                            : StatusCodes.Status400BadRequest, response);
        }

        [HttpPut("{id}/change-status/{activate}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] TransactionUpdateDto transactionUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<TransactionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var response = await _transactionService.SetActivateAsync(id, transactionUpdate);

            return response
                      ? NoContent()
                      : BadRequest(new ApiResponse<TransactionDto>
                      {
                          Succeeded = false,
                          Errors = new List<string> { $"No se ha podido actualizar el registro." }
                      });
        }
    }
}