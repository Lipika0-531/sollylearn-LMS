using System.ComponentModel.DataAnnotations;

namespace SollyLearn.API.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
