using SollyLearn.API.Models.Domain;

namespace SollyLearn.API.Repository
{
    public interface ITechStackRepository
    {
        Task<List<TechStack>> GetAllTechStackAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000);

        Task<Video?> GetByVideoIdAsync(Guid videoId);

        Task<TechStack?> GetByTechStackIdAsync(Guid techStackId);

        Task<TechStack> CreateTechStackAsync(TechStack techStack);

        Task<TechStack?> UpdateTechStackAsync(Guid id, TechStack techStack);

        Task<TechStack?> DeleteTechStackAsync(Guid id);
    }
}
