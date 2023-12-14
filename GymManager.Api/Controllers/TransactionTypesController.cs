using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionTypesController : Controller
    {

        private readonly ITransactionTypeServcie _transactionTypeServcie;

        public TransactionTypesController(ITransactionTypeServcie transactionTypeServcie)
        {
            _transactionTypeServcie = transactionTypeServcie;
        }

        [HttpGet]
        public async Task<ApiResponse<List<TransactionTypeDto>>> GetAll()
        {
            return await _transactionTypeServcie.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<TransactionTypeDto>> Get(int id)
        {
            return await _transactionTypeServcie.GetByIdAsync(id);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _transactionTypeServcie.DeleteAsync(id);

            return result
                        ? NoContent()
                        : BadRequest(
                            new ApiResponse<TransactionTypeDto>
                            {
                                Succeeded = false,
                                Errors = new List<string> { $"No se ha podido eliminar el registro." }
                            });
        }
    }
}