using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using SollyLearn.API.Models.Domain;
using SollyLearn.API.Data;

namespace SollyLearn.API.Repository
{
    public class SQLTechStackRepository : ITechStackRepository
    {
        private readonly SollyLearnDbContext dbContext;

        public SQLTechStackRepository(SollyLearnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TechStack> CreateTechStackAsync(TechStack techStack)
        {
            await dbContext.TechStacks.AddAsync(techStack);
            await dbContext.SaveChangesAsync();
            return techStack;
        }

        public async Task<TechStack?> DeleteTechStackAsync(Guid id)
        {
            var techStackToDelete = await dbContext.TechStacks.FirstOrDefaultAsync(x => x.Id == id);

            if (techStackToDelete == null)
            {
                return null;
            }

            dbContext.TechStacks.Remove(techStackToDelete);
            await dbContext.SaveChangesAsync();
            return techStackToDelete;
        }

        public async Task<List<TechStack>> GetAllTechStackAsync(string? filterOn, string? filterQuery,
            string? sortBy = null, bool isAscending = true, 
            int pageNumber = 1, int pageSize = 1000 )
        {
            var techstacks = dbContext.TechStacks.AsQueryable();

            //filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    techstacks = techstacks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    techstacks = isAscending ? techstacks.OrderBy(x => x.Name) : techstacks.OrderByDescending(x => x.Name);
                }
            }

            var skipResults = (pageNumber - 1) * pageSize;

            return await techstacks.Skip(skipResults).Take(pageSize).ToListAsync();

        }

        public async Task<TechStack?> GetByTechStackIdAsync(Guid techStackId)
        {
            return await dbContext.TechStacks.FirstOrDefaultAsync(x => x.Id == techStackId);
        }

        public async Task<Video?> GetByVideoIdAsync(Guid videoId)
        {
            return await dbContext.Videos.FirstOrDefaultAsync(x => x.Id == videoId);
        }

        public async Task<TechStack?> UpdateTechStackAsync(Guid id, TechStack techStack)
        {
            var techStackDomainModel = await dbContext.TechStacks.FirstOrDefaultAsync(x => x.Id == id);

            if(techStackDomainModel == null)
            {
                return null;
            }

            techStackDomainModel.Name = techStack.Name;
            techStackDomainModel.Description = techStack.Description;
            techStackDomainModel.TechStackImageURL = techStack.TechStackImageURL;

            await dbContext.SaveChangesAsync();
            return techStackDomainModel;
        }
        
    }
}
