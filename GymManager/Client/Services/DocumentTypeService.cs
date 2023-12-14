using System.Net.Http.Json;
using GymManager.Entities.Dtos;
using GymManager.Entities.Interfaces.Services;
using GymManager.Entities.Responses;

namespace GymManager.Client.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly HttpClient _httpClient;

        public DocumentTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<DocumentTypeDto>>> GetAllAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ApiResponse<IEnumerable<DocumentTypeDto>>>($"api/DocumentTypes");

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<ApiResponse<DocumentTypeDto>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

