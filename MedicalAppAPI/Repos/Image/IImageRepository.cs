using MedicalAppAPI.Models.Domains;

namespace MedicalAppAPI.Repos.Image
{
    public interface IImageRepository
    {
        Task<ImageUploads> Upload(ImageUploads image);
    }
}
