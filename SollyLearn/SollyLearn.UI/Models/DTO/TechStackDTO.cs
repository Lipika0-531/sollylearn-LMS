namespace SollyLearn.UI.Models.DTO
{
    public class TechStackDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string? TechStackImageURL { get; set; }

        public IEnumerable<VideoDTO> Videos { get; set; }
    }
}
