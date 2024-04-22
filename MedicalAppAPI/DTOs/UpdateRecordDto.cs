namespace MedicalAppAPI.DTOs
{
    public class UpdateRecordDto
    {
        public DateTime Date { get; set; }
        public string BloodPressure { get; set; }
        public string HeartRate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Temperature { get; set; }
        public int CalculateAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        public string Notes { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }
    }
}

