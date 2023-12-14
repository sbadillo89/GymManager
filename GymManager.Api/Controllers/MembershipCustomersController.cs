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
    public class MembershipCustomersController : ControllerBase
    {
        private readonly IMembershipCustomerService _membershipCustomerService;
        private readonly IMapper _mapper;

        public MembershipCustomersController(IMembershipCustomerService membershipCustomerService, IMapper mapper)
        {
            _mapper = mapper;
            _membershipCustomerService = membershipCustomerService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<MembershipCustomerDto>>> Get()
        {
            return await _membershipCustomerService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _membershipCustomerService.GetByIdAsync(id);

            return StatusCode(response.Succeeded ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MembershipCustomerRegistrationDto membershipCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<MembershipCustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var userId = User.FindFirst("id")?.Value;
            var entityMapped = _mapper.Map<MembershipCustomers>(membershipCustomer);
            entityMapped.UserId = userId;

            var response = await _membershipCustomerService.InsertAsync(entityMapped);

            return StatusCode(response!.Succeeded
                            ? StatusCodes.Status201Created
                            : StatusCodes.Status400BadRequest, response);
        }


        [HttpPut("{id}/change-status/{activate}")]
        public async Task<IActionResult> UpdateStatus(Guid id, bool activate)
        {
            var response = await _membershipCustomerService.SetActivateAsync(id, activate);

            return response
                      ? NoContent()
                      : BadRequest(new ApiResponse<MembershipCustomerDto>
                      {
                          Succeeded = false,
                          Errors = new List<string> { $"No se ha podido actualizar el registro." }
                      });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool response = await _membershipCustomerService.DeleteAsync(id);

            return response
                        ? NoContent()
                        : BadRequest(new ApiResponse<MembershipCustomerDto>
                        {
                            Succeeded = false,
                            Errors = new List<string> { $"No se ha podido eliminar el registro." }
                        });
        }
    }
}

