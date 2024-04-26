using MedicalAppAPI.Models.Domains;
using MiNET.Utils;

namespace MedicalAppAPI.Repos
{
    public interface IMedicalRecordActions
    {
        Task<List<MedicalRecord>> GetAllMedicalRecordAsync();
        Task<MedicalRecord?> GetMedicalRecordByIdAsync(Guid id);
        Task<MedicalRecord> AddMedicalRecordAsync(MedicalRecord record);
        Task<MedicalRecord?> UpdateMedicalRecordAsync(Guid id, MedicalRecord record);
    }
}
