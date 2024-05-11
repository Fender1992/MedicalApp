using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppAPI.Models.Domains
{
    public class ImageUploads
    {
        public Guid Id { get; set; }
        [NotMapped] 
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; }
    }
}
