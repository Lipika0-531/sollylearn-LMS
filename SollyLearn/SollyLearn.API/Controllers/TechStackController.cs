using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SollyLearn.API.CustomActionFilters;
using SollyLearn.API.Data;
using SollyLearn.API.Models.Domain;
using SollyLearn.API.Models.DTO;
using SollyLearn.API.Repository;

namespace SollyLearn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechStackController : ControllerBase
    {
        private readonly SollyLearnDbContext dbContext;
        private readonly ITechStackRepository techStackRepository;
        private readonly IMapper mapper;

        public TechStackController(SollyLearnDbContext dbContext, ITechStackRepository techStackRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.techStackRepository = techStackRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateTechStack([FromBody] AddTechStackRequestDto addTechStackRequestDto)
        {
            //var techStack = await dbContext.TechStack.FirstOrDefaultAsync(t => t.Id == addVideoRequestDto.TechStackId);

            /*var techStack = new TechStack
            {
                Id = Guid.NewGuid(), 
                Name = addTechStackRequestDto.Name,
                Description = addTechStackRequestDto.Description,
                TechStackImageURL = addTechStackRequestDto.TechStackImageURL
            };*/

            var techStack = mapper.Map<TechStack>(addTechStackRequestDto);

            techStack = await techStackRepository.CreateTechStackAsync(techStack);

            var techStackDto = mapper.Map<TechStackDTO>(techStack);
            return CreatedAtAction(nameof(GetById), new { id = techStackDto.Id }, techStackDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var techStackDomainModel = await techStackRepository.GetByTechStackIdAsync(id);
            if (techStackDomainModel == null)
            {
                return NotFound();
            }

            var techStackDto = mapper.Map<TechStackDTO>(techStackDomainModel);
            //Return dto to client
            return Ok(techStackDto);
        }

       /* [HttpGet]
        [Route("Video/{id:guid}")]
        public async Task<IActionResult> GetByVideoId([FromRoute] Guid id)
        {
            var techStackDomainModel = await techStackRepository.GetByVideoIdAsync(id);
            if (techStackDomainModel == null)
            {
                return NotFound();
            }
            var techStackDto = mapper.Map<VideoDTO>(techStackDomainModel);
            //Return dto to client
            return Ok(techStackDto);
        }*/

        [HttpGet]
       /* [Authorize(Roles = "Reader,Writer")]*/
        public async Task<IActionResult> GetAllTechStacks([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var techStackDomain = await techStackRepository.GetAllTechStackAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            var techStackDto = mapper.Map<List<TechStackDTO>>(techStackDomain);
            //Return DTOs
            return Ok(techStackDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
       /* [Authorize(Roles = "Writer")]*/
        public async Task<IActionResult> UpdateTechStack([FromRoute] Guid id, [FromBody] UpdateTechStackRequestDto updateTechStackRequest)
        {
            
            var techstackDomainModel = mapper.Map<TechStack>(updateTechStackRequest);
            techstackDomainModel = await techStackRepository.UpdateTechStackAsync(id, techstackDomainModel);
            if (techstackDomainModel == null)
            {
                return NotFound();
            }

            var techStackDto = mapper.Map<TechStackDTO>(techstackDomainModel);
            return Ok(techStackDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
       /* [Authorize(Roles = "Writer")]*/
        public async Task<IActionResult> DeleteTechStack([FromRoute] Guid id)
        {
            var techStackToDelete = await techStackRepository.DeleteTechStackAsync(id);

            if (techStackToDelete == null)
            {
                return NotFound();
            }

            var techStackDto = mapper.Map<TechStackDTO>(techStackToDelete);
            return Ok(techStackDto);
        }
    }
}
