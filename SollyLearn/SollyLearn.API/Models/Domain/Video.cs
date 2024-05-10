namespace SollyLearn.API.Models.Domain
{
    public class Video
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public Guid TechStackId { get; set; }

        public TechStack TechStack { get; set; }

        public string FilePath { get; set; }

    }
}
