using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class MembershipTypesController : ControllerBase
    {
        private readonly IMembershipTypeService _membershipTypeService;
        private readonly IMapper _mapper;

        public MembershipTypesController(IMembershipTypeService membershipTypeService, IMapper mapper)
        {
            _membershipTypeService = membershipTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<MembershipTypeDto>>> GetAll()
        {
            return await _membershipTypeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _membershipTypeService.GetByIdAsync(id);

            return StatusCode(response.Succeeded ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MembershipTypeRegistrationDto membershipTypeRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<MembershipTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var userId = User.FindFirst("id")?.Value;
            var entityMapped = _mapper.Map<MembershipTypes>(membershipTypeRegistration);

            entityMapped.UserId = userId;

            var response = await _membershipTypeService.InsertAsync(entityMapped);

            return StatusCode(response!.Succeeded
                            ? StatusCodes.Status201Created
                            : StatusCodes.Status400BadRequest, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] MembershipTypUpdateDto membershipUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<MembershipTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Solicitud inválida." }
                });
            }

            var entityMapped = _mapper.Map<MembershipTypes>(membershipUpdate);
            var response = await _membershipTypeService.UpdateAsync(id, entityMapped);

            return response
                      ? NoContent()
                      : BadRequest(new ApiResponse<MembershipTypeDto>
                      {
                          Succeeded = false,
                          Errors = new List<string> { $"No se ha podido actualizar el registro." }
                      });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool response = await _membershipTypeService.DeleteAsync(id);

            return response
                        ? NoContent()
                        : BadRequest(new ApiResponse<MembershipTypeDto>
                        {
                            Succeeded = false,
                            Errors = new List<string> { $"No se ha podido eliminar el registro." }
                        });
        }
    }
}

