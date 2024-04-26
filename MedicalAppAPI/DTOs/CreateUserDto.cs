using MedicalAppAPI.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppAPI.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
        [Required]
        public string email { get; set; }
        public string? phoneNumber { get; set; }

        [Required]
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
