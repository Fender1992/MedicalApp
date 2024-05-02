using MiNET.Utils;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppAPI.Models.Domains
{
    public class MedicalRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime Date {  get; set; }
        [Required]
        public string BloodPressure {  get; set; }
        [Required]
        public string HeartRate { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public double Temperature {  get; set; }
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        [Required]
        public string Notes { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Description { get; set; }
    }
    
}
