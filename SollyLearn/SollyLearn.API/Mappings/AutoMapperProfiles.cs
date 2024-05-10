using AutoMapper;
using SollyLearn.API.Models.Domain;
using SollyLearn.API.Models.DTO;

namespace SollyLearn.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Video, VideoDTO>().ReverseMap();
            CreateMap<AddVideoRequestDto, Video>().ReverseMap();
            CreateMap<UpdateVideoRequestDto, Video>().ReverseMap();

            CreateMap<TechStack, TechStackDTO>().ReverseMap();
            CreateMap<AddTechStackRequestDto, TechStack>().ReverseMap();
            CreateMap<UpdateTechStackRequestDto, TechStack>().ReverseMap();
        }
    }
}
