using Microsoft.EntityFrameworkCore;
using SollyLearn.API.Data;
using SollyLearn.API.Models.Domain;
using SollyLearn.API.Models.DTO;

namespace SollyLearn.API.Repository
{
    public class SQLVideoRepository : IVideoRepository
    {
        private readonly SollyLearnDbContext dbContext;

        public SQLVideoRepository(SollyLearnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Video> CreateVideoAsync(Video video)
        {
           await dbContext.Videos.AddAsync(video);
           await dbContext.SaveChangesAsync();
            return video;
        }

        public async Task<Video?> DeleteVideoAsync(Guid id)
        {
            var videoToDelete = await dbContext.Videos.FirstOrDefaultAsync(x => x.Id == id);

            if (videoToDelete == null)
            {
                return null;
            }
            dbContext.Videos.Remove(videoToDelete);
            await dbContext.SaveChangesAsync();
            return videoToDelete;
        }

        public async Task<List<Video>> GetAllVideosAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true,
             int pageNumber = 1, int pageSize = 1000
            )
        {
            var videos = dbContext.Videos.Include("TechStack").AsQueryable();

            //Filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    videos = videos.Where(x => x.Title.Contains(filterQuery));
                }
            }

            //Sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    videos = isAscending ? videos.OrderBy(x => x.Title) : videos.OrderByDescending(x => x.Title);
                }
            }

            //Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await videos.Skip(skipResults).Take(pageSize).ToListAsync();
            //return await dbContext.Videos.Include("TechStack").ToListAsync();
        }

        public async Task<Video?> GetByIdAsync(Guid id)
        {
            return await dbContext.Videos.Include("TechStack").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Video>> GetByTechStackIdAsync(Guid techStackId)
        {
            return await dbContext.Videos.Where(x => x.TechStackId == techStackId).ToListAsync();
        }

        public async Task<Video?> UpdateVideoAsync(Guid id, Video video)
        {
            var videoDomainModel = await dbContext.Videos.FirstOrDefaultAsync(x => x.Id == id);

            if (videoDomainModel == null)
            {
                return null;
            }

            videoDomainModel.Description = video.Description;
            videoDomainModel.Title = video.Title;
            videoDomainModel.FilePath = video.FilePath;

            await dbContext.SaveChangesAsync();
            return videoDomainModel;
        }
    }
}
