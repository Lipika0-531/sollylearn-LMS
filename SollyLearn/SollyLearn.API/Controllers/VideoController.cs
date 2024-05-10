using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SollyLearn.API.CustomActionFilters;
using SollyLearn.API.Data;
using SollyLearn.API.Models.Domain;
using SollyLearn.API.Models.DTO;
using SollyLearn.API.Repository;
using System.Text.Json;

namespace SollyLearn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly SollyLearnDbContext _dbContext;
        private readonly IVideoRepository videoRepository;
        private readonly IMapper mapper;
        private readonly ILogger<VideoController> logger;

        public VideoController(SollyLearnDbContext dbContext, 
            IVideoRepository videoRepository, 
            IMapper mapper,
            ILogger<VideoController> logger)
        {
            _dbContext = dbContext;
            this.videoRepository = videoRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //GET : /api/videos?filterOn=Title&filterQuery=C#&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
       /*[Authorize(Roles = "Reader,Writer")]*/
        public async Task<IActionResult> GetAllVideos([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            /*var videos = new List<Video>
            {
                new Video
                {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Description = "My First Video",
                Title = "Title",
                TechStack =
                    new TechStack
                    {
                        Id = Guid.NewGuid(),
                        Name = "C#",
                        TechStackImageURL = string.Empty,
                        Description = "First C# Video",
                    },
                TechStackId = Guid.NewGuid(),
                FilePath ="FilePath of the First video",
                },
                new Video
                {
                    Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Description = "My Second Video",
                Title = "SecondTitle",
                TechStack =
                    new TechStack
                    {
                        Id = Guid.NewGuid(),
                        Name = "FrontEnd",
                        TechStackImageURL = string.Empty,
                        Description = "First Frontend Video",
                    },
                TechStackId = Guid.NewGuid(),
                FilePath ="FilePath of the Second video",
                }

            };*/
            logger.LogInformation("GetAll Videos method was invoked");
            //Get data from database - domain models
            var videosDomain = await videoRepository.GetAllVideosAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            //Map domain models to dtos
            /* var videoDto = new List<VideoDTO>();
             foreach (var videoDomain in videosDomain)
             {
                 videoDto.Add(new VideoDTO()
                 {
                     Id = videoDomain.Id,
                     Title = videoDomain.Title,
                     Description = videoDomain.Description,
                     DateTime = videoDomain.DateTime,
                     TechStack = videoDomain.TechStack,
                 });
             }*/

            logger.LogInformation($"Finished GetAllVideos request with data : {JsonSerializer.Serialize(videosDomain)}");

            var videoDto = mapper.Map<List<VideoDTO>>(videosDomain);
            //Return DTOs
            return Ok(videoDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
       /* [Authorize(Roles = "Reader,Writer")]*/
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Get the data from database - domainModel
            logger.LogInformation("GetById Videos method was invoked");

            var videoDomainModel = await videoRepository.GetByIdAsync(id);
            if (videoDomainModel == null)
            {
                return NotFound();
            }

            //Map domain model to DTO
            /* var videoDto = new VideoDTO
             {
                 Id = videoDomainModel.Id,
                 Title = videoDomainModel.Title,
                 Description = videoDomainModel.Description,
                 DateTime = videoDomainModel.DateTime,
                 TechStack = videoDomainModel.TechStack,
             };*/

            logger.LogInformation($"Finished GetAllVideosById request with data : {JsonSerializer.Serialize(videoDomainModel)}");

            var videoDto = mapper.Map<VideoDTO>(videoDomainModel);
            //Return dto to client
            return Ok(videoDto);
        }

        [HttpGet]
        [Route("TechStack/{techstackId:Guid}")]
      /*  [Authorize(Roles = "Reader,Writer")]*/
        public async Task<IActionResult> GetByTechStackId([FromRoute] Guid techstackId)
        {
            var videoDomainModel = await videoRepository.GetByTechStackIdAsync(techstackId);
            if (videoDomainModel == null)
            {
                return NotFound();
            }

            /*var videoDto = new VideoDTO
            {
                Id = videoDomainModel.Id,
                Title = videoDomainModel.Title,
                Description = videoDomainModel.Description,
                DateTime = videoDomainModel.DateTime,
                TechStack = videoDomainModel.TechStack,
            };*/
            var videoDto = mapper.Map<List<VideoDTO>>(videoDomainModel);
            //Return dto to client
            return Ok(videoDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> CreateVideo([FromBody] AddVideoRequestDto addVideoRequestDto)
        {

            var techStack = await _dbContext.TechStacks.FirstOrDefaultAsync(t => t.Id == addVideoRequestDto.TechStackId);
            //Map dto to domain model
            /*var videoDomainModel = new Video
            {
                TechStackId = addVideoRequestDto.TechStackId,
                TechStack = techStack,
                DateTime = DateTime.Now,
                Title = addVideoRequestDto.Title,
                Description = addVideoRequestDto.Description,
                FilePath = addVideoRequestDto.FilePath
            };*/
            var videoDomainModel = mapper.Map<Video>(addVideoRequestDto);

            videoDomainModel = await videoRepository.CreateVideoAsync(videoDomainModel);

            //Map domain model back to dto
            /*var videoDto = new VideoDTO
            {
                Id = videoDomainModel.Id,
                Title = videoDomainModel.Title,
                Description = videoDomainModel.Description,
                DateTime = videoDomainModel.DateTime,
                TechStack = videoDomainModel.TechStack,
                TechStackId = videoDomainModel.TechStackId
            };*/
            var videoDto = mapper.Map<VideoDTO>(videoDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = videoDto.Id }, videoDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> UpdateVideo([FromRoute] Guid id, [FromBody] UpdateVideoRequestDto updateVideoRequestDto)
        {
           
            /*var video = new Video
            {
                Description = updateVideoRequestDto.Description,
                Title = updateVideoRequestDto.Title,
                FilePath = updateVideoRequestDto.FilePath
            };*/
            var video = mapper.Map<Video>(updateVideoRequestDto);

            video = await videoRepository.UpdateVideoAsync(id, video);
            if (video == null)
            {
                return NotFound();
            }
            /* video.Description = updateVideoRequestDto.Description;
             video.Title = updateVideoRequestDto.Title;
             video.FilePath = updateVideoRequestDto.FilePath;

             await _dbContext.SaveChangesAsync();*/
            /*var videoDto = new VideoDTO
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                DateTime = video.DateTime,
                TechStack = video.TechStack,
                TechStackId = video.TechStackId,
            };*/
            var videoDto = mapper.Map<VideoDTO>(video);
            return Ok(videoDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> DeleteVideo([FromRoute] Guid id)
        {
            var videoToDelete = await videoRepository.DeleteVideoAsync(id);

            if (videoToDelete == null)
            {
                return NotFound();
            }
            /*_dbContext.Videos.Remove(videoToDelete);
            await _dbContext.SaveChangesAsync();*/
            /*var videoDto = new VideoDTO
            {
                Id = videoToDelete.Id,
                Title = videoToDelete.Title,
                Description = videoToDelete.Description,
                DateTime = videoToDelete.DateTime,
                TechStack = videoToDelete.TechStack,
                TechStackId = videoToDelete.TechStackId,
            };*/
            var videoDto = mapper.Map<VideoDTO>(videoToDelete);
            return Ok(videoDto);
        }
    }
}
