using System.ComponentModel.DataAnnotations;

namespace SollyLearn.API.Models.DTO
{
    public class AddTechStackRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage ="Name has to be maximum of 100 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description has to be maximum of 1000 characters")]
        public string Description { get; set; }

        public string? TechStackImageURL { get; set; }
    }
}
