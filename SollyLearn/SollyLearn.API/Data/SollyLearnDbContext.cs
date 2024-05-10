using Microsoft.EntityFrameworkCore;
using SollyLearn.API.Models.Domain;

namespace SollyLearn.API.Data
{
    public class SollyLearnDbContext : DbContext
    {
        public SollyLearnDbContext(DbContextOptions<SollyLearnDbContext> dbContextoptions) : base(dbContextoptions)
        {
        }

        public DbSet<Video> Videos { get; set; }

        public DbSet<TechStack> TechStacks { get; set; }

        public DbSet<Image> Images { get; set; }

     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var videos = new List<Video>
           {
               new Video()
               {
               Id = Guid.NewGuid(),
               DateTime = DateTime.Now,
               Description = "My First Video",
               Title = "Title",
               *//*TechStack =
                   new TechStack
                   {
                       Id = Guid.Parse("7fc2efac-fe9f-4996-af23-b4f127bb7752"),
                       Name = "C#",
                       TechStackImageURL = string.Empty,
                       Description = "First C# Video",
                   },*//*
               TechStackId =Guid.Parse("7fc2efac-fe9f-4996-af23-b4f127bb7752"),
               FilePath ="FilePath of the First video",
               },
               new Video
               {
                   Id = Guid.NewGuid(),
               DateTime = DateTime.Now,
               Description = "My Second Video",
               Title = "SecondTitle",
              *//* TechStack =
                   new TechStack
                   {
                       Id = Guid.Parse("505037a5-be9d-4b30-b1ab-6dcff18ae655"),
                       Name = "FrontEnd",
                       TechStackImageURL = string.Empty,
                       Description = "First Frontend Video",
                   },*//*
               TechStackId = Guid.Parse("505037a5-be9d-4b30-b1ab-6dcff18ae655"),
               FilePath ="FilePath of the Second video",
               }

           };

            modelBuilder.Entity<Video>().HasData(videos);

            var techStack = new List<TechStack>
            {
                new TechStack()
                   {
                       Id = Guid.Parse("505037a5-be9d-4b30-b1ab-6dcff18ae655"),
                       Name = "FrontEnd",
                       TechStackImageURL = string.Empty,
                       Description = "First Frontend Video",
                   },
                new TechStack
                   {
                       Id = Guid.Parse("7fc2efac-fe9f-4996-af23-b4f127bb7752"),
                       Name = "C#",
                       TechStackImageURL = string.Empty,
                       Description = "First C# Video",
                   },
                new TechStack
                   {
                       Id = Guid.Parse("a4eb5696-0e8e-417b-bf47-cdcca646e9bb"),
                       Name = "LabView",
                       TechStackImageURL = string.Empty,
                       Description = "First LabView Video",
                   },
                new TechStack
                   {
                       Id = Guid.Parse("e93cb985-4533-4df8-bf6b-0e4e4c18d320"),
                       Name = "Python",
                       TechStackImageURL = string.Empty,
                       Description = "First Python Video",
                   },
                new TechStack
                   {
                       Id = Guid.Parse("41b65a0e-1097-4759-a51c-e031d6ceb8b6"),
                       Name = "Utkarsh",
                       TechStackImageURL = string.Empty,
                       Description = "First Learning Video",
                   },
            };

            modelBuilder.Entity<TechStack>().HasData(techStack);
        }*/
    }
}
