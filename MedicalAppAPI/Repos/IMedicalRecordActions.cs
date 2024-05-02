using MedicalAppAPI.Models.Domains;
using MiNET.Utils;

namespace MedicalAppAPI.Repos
{
    public interface IMedicalRecordActions
    {
        Task<List<MedicalRecord>> GetAllMedicalRecordAsync(string? filterOn, string? filterQuery,
            int pageNumber = 1, int pageSize = 1000);
        Task<MedicalRecord?> GetMedicalRecordByIdAsync(Guid id);
        Task<MedicalRecord> AddMedicalRecordAsync(MedicalRecord record);
        Task<MedicalRecord?> UpdateMedicalRecordAsync(Guid id, MedicalRecord record);
    }
}
