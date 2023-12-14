using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DocumentTypesController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<DocumentTypeDto>>> GetAllAsync()
        {
            var documentTypes = await _documentTypeService.GetAllAsync();

            return documentTypes;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _documentTypeService.GetByIdAsync(id);

            return response.Succeeded
                    ? Ok(response)
                    : BadRequest(response);
        }
    }
}