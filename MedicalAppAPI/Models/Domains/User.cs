using MedicalAppAPI.DTOs;

namespace MedicalAppAPI.Models.Domains
{
    public class User
    {
        public Guid Id { get; set; } 
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? phoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        public virtual ICollection<MedicalRecordDto> MedicalRecordsDto { get; set; }
    }

    public enum Gender
    {
        Male, 
        Female,
        Other
    }
}
