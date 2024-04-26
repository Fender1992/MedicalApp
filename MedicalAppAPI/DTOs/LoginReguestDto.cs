using System.ComponentModel.DataAnnotations;

namespace MedicalAppAPI.DTOs
{
    public class LoginReguestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
