using System.ComponentModel.DataAnnotations;

namespace MedicalAppAPI.DTOs
{
    public class ImageUploadRequestDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
