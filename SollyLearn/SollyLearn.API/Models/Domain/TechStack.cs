namespace SollyLearn.API.Models.Domain
{
    public class TechStack
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? TechStackImageURL {  get; set; }
    }
}