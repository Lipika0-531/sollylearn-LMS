using Newtonsoft.Json;
using SollyLearn.UI.Models.DTO;

namespace SollyLearn.UI.Models.Service
{
    public class VideoService
    {

        private readonly HttpClient _httpClient;
        /*private readonly string _apiUrl = "https://localhost:7253/api/Video";*/

        public VideoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /* public async Task<IEnumerable<VideoDTO>> GetVideosAsync()
         {
             var response = await _httpClient.GetAsync(_apiUrl);
             if (response.IsSuccessStatusCode)
             {
                 var content = await response.Content.ReadAsStringAsync();
                 var videos = JsonConvert.DeserializeObject<IEnumerable<VideoDTO>>(content);
                 return videos;
             }
             else
             {
                 // Handle error
                 return Enumerable.Empty<VideoDTO>();
             }

         }*/

          public async Task<List<VideoDTO>> OnGetAsync(Guid techStackId)
          {
              var response = await _httpClient.GetAsync($"https://localhost:7253/api/Video/TechStack/{techStackId}");
              if (response.IsSuccessStatusCode)
              {
                  var content = await response.Content.ReadAsStringAsync();
                  var videos = JsonConvert.DeserializeObject<List<VideoDTO>>(content);
                  return videos;
              }
              else
              {
                // Handle error
                return null;
              }
          }

    }
}
