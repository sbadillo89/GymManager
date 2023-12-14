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
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly ICustomerDimensionService _customerDimensionService;
        public readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper, ICustomerDimensionService customerDimensionService)
        {
            _mapper = mapper;
            _customerService = customerService;
            _customerDimensionService = customerDimensionService;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<CustomerDto>>> GetAll()
        {
            return await _customerService.GetAllAsync();
        }

        [HttpGet("get-birthdays-by-month")]
        public async Task<ApiResponse<IEnumerable<CustomerDto>>> GetBirthdaysByMonth(DateTime date)
        {
            return await _customerService.GetBirthdaysByMonthAsync(date);
        }

        [HttpGet("{documentNumber}")]
        public async Task<IActionResult> GetById(string documentNumber)
        {
            var response = await _customerService.GetByDocumentAsync(documentNumber);

            return StatusCode(response.Succeeded ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, response);
        }

        [HttpGet("{documentNumber}/get-memberships")]
        public async Task<ApiResponse<List<MembershipCustomerDto>>> GetAllByCustomer(string documentNumber)
        {
            return await _customerService.GetAllMembershipsByDocumentAsync(documentNumber);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRegistrationDto customerRegistration)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<CustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var userId = User.FindFirst("id")?.Value;
            var entityMapped = _mapper.Map<Customers>(customerRegistration);
            entityMapped.UserId = userId;

            var response = await _customerService.InsertAsync(entityMapped);

            return StatusCode(response!.Succeeded
                            ? StatusCodes.Status201Created
                            : StatusCodes.Status400BadRequest, response);
        }

        [HttpPut("{documentNumber}")]
        public async Task<IActionResult> Put(string documentNumber, [FromBody] CustomerRegistrationDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<CustomerDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var entityMapped = _mapper.Map<Customers>(customer);
            var response = await _customerService.UpdateAsync(documentNumber, entityMapped);

            return response
                      ? NoContent()
                      : BadRequest(new ApiResponse<MembershipTypeDto>
                      {
                          Succeeded = false,
                          Errors = new List<string> { $"No se ha podido actualizar el registro." }
                      });
        }

        [HttpPut("{documentNumber}/change-status/{activate}")]
        public async Task<IActionResult> ChangeActivate(string documentNumber, bool activate)
        {
            var response = await _customerService.SetActivateAsync(documentNumber, activate);

            return response
                      ? NoContent()
                      : BadRequest(new ApiResponse<MembershipTypeDto>
                      {
                          Succeeded = false,
                          Errors = new List<string> { $"No se ha podido actualizar el registro." }
                      });
        }

        [HttpGet("dimesions")]
        public async Task<ApiResponse<IEnumerable<CustomerDimensionDto>>> GetDimensions(string documentNumber)
        {
            return await _customerDimensionService.GetAllByCustomerAsync(documentNumber);
        }

        [Authorize]
        [HttpPost("dimensions")]
        public async Task<IActionResult> PostDimensions([FromBody] CustomerDimensionRegistrationDto customerDimension)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<CustomerDimensionDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var entityMapped = _mapper.Map<CustomerDimensions>(customerDimension);

            var response = await _customerDimensionService.InsertAsync(entityMapped);

            return StatusCode(response!.Succeeded
                            ? StatusCodes.Status201Created
                            : StatusCodes.Status400BadRequest, response);
        }

    }
}

