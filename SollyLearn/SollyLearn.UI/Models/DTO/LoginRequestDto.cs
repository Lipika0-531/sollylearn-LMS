using System.ComponentModel.DataAnnotations;

namespace SollyLearn.UI.Models.DTO
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
