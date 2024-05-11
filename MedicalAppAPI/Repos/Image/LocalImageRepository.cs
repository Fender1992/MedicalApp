using MedicalAppAPI.Data;
using MedicalAppAPI.Models.Domains;

namespace MedicalAppAPI.Repos.Image
{
    public class LocalImageRepository: IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MedicalRecordDbContext _medicalRecordDbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, 
            MedicalRecordDbContext medicalRecordDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _medicalRecordDbContext = medicalRecordDbContext;
        }

        public async Task<ImageUploads> Upload(ImageUploads image)
        {
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", image.FileName, image.FileExtension);

            //upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var prefixAccessor = _httpContextAccessor.HttpContext.Request;

            var urlFilePath = $"{prefixAccessor.Scheme}://{prefixAccessor.Host}{prefixAccessor.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            await _medicalRecordDbContext.Images.AddAsync(image);
            await _medicalRecordDbContext.SaveChangesAsync();

            return image;
        }
    }
}
