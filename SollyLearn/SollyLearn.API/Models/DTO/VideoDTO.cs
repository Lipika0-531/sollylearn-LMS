using SollyLearn.API.Models.Domain;

namespace SollyLearn.API.Models.DTO
{
    public class VideoDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid TechStackId { get; set; }
        public DateTime DateTime { get; set; }

        public TechStackDTO TechStack { get; set; }

        public string FilePath { get; set; }
    }
}
