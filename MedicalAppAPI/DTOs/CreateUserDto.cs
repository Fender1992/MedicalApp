using MedicalAppAPI.Models.Domains;

namespace MedicalAppAPI.DTOs
{
    public class CreateUserDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
        public string email { get; set; }
        public string? phoneNumber { get; set; }
        public string password { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
