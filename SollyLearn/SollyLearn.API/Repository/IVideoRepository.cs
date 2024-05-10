using SollyLearn.API.Models.Domain;

namespace SollyLearn.API.Repository
{
    public interface IVideoRepository
    {
        Task<List<Video>> GetAllVideosAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);

        Task<Video?> GetByIdAsync(Guid id);

        Task<List<Video>> GetByTechStackIdAsync(Guid techStackId);

        Task<Video> CreateVideoAsync(Video video);

        Task<Video?> UpdateVideoAsync(Guid id, Video video);

        Task<Video?> DeleteVideoAsync(Guid id);
    }
}
