using MedicalAppAPI.DTOs;
using MedicalAppAPI.Migrations;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppAPI.Models.Domains
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? phoneNumber { get; set; }
        [Required]
        public Gender Gender { get; set; }
        
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
        //public virtual ICollection<MedicalRecordDto> MedicalRecordsDto { get; set; }
    }
        
    }

public enum Gender
{
    Male,
    Female,
    Other
}
