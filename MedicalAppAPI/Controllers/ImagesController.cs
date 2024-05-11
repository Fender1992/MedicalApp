using MedicalAppAPI.DTOs;
using MedicalAppAPI.Models.Domains;
using MedicalAppAPI.Repos.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDto request )
        {
            ValidateFileUpload(request);
            if(ModelState.IsValid)
            {
                var imageDomainModel = new ImageUploads
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };
                //some code
                await _imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }

            return BadRequest(ModelState);

        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExt = new string[] { ".jpg", ".jpeg", ".png" };

            if(!allowedExt.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if(request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File is larger than 10MB, upload smaller file.");
            }
        }
    }
}
