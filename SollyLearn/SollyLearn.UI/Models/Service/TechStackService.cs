using Newtonsoft.Json;
using SollyLearn.UI.Models.DTO;
using System.Text;

namespace SollyLearn.UI.Models.Service
{
    public class TechStackService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://localhost:7253/api/TechStack";

        public TechStackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TechStackDTO>> GetTechStacksAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var techStacks = JsonConvert.DeserializeObject<IEnumerable<TechStackDTO>>(content);
                return techStacks;
            }
            else
            {
                // Handle error
                return Enumerable.Empty<TechStackDTO>();
            }
        }

        public async Task<TechStackDTO> UpdateTechStackAsync(Guid id, UpdateTechStackRequestDto updateTechStackRequest)
        {
            var json = JsonConvert.SerializeObject(updateTechStackRequest);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var updatedTechStack = JsonConvert.DeserializeObject<TechStackDTO>(content);
                return updatedTechStack;
            }
            else
            {
                // Handle error
                return null;
            }
        }

        public async Task<TechStackDTO> DeleteTechStackAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var deletedTechStack = JsonConvert.DeserializeObject<TechStackDTO>(content);
                return deletedTechStack;
            }
            else
            {
                // Handle error
                return null;
            }
        }

    }
}
