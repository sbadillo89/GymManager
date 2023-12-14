using AutoMapper;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;
using GymManager.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly DocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public DocumentTypeService(DocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<DocumentTypeDto>>> GetAllAsync()
        {
            var documentTypes = await _documentTypeRepository.GetAll().ToListAsync();


            return new ApiResponse<IEnumerable<DocumentTypeDto>>
            {
                Succeeded = true,
                Data = _mapper.Map<List<DocumentTypeDto>>(documentTypes)
            };
        }

        public async Task<ApiResponse<DocumentTypeDto>> GetByIdAsync(Guid id)
        {
            var existingDocumentType = await _documentTypeRepository.GetById(id);
            if (existingDocumentType == null)
            {
                return new ApiResponse<DocumentTypeDto>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No se encontró la información del tipo de documento." }
                };
            }

            return new ApiResponse<DocumentTypeDto>
            {
                Succeeded = true,
                Data = _mapper.Map<DocumentTypeDto>(existingDocumentType)
            };
        }
    }
}

