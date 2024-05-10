using System.ComponentModel.DataAnnotations;

namespace SollyLearn.API.Models.DTO
{
    public class UpdateVideoRequestDto
    {
        // public Guid TechStackId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Title has to be maximum of 100 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description has to be maximum of 1000 characters")]
        public string Description { get; set; }

        public string FilePath { get; set; }
    }
}
