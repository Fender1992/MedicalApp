using MedicalAppAPI.Data;
using MedicalAppAPI.Models.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppAPI.Repos
{
    public class SQLMedicalRecordRepository : IMedicalRecordActions
    {
        private readonly MedicalRecordDbContext _medicalRecordDbContext;

        public SQLMedicalRecordRepository(MedicalRecordDbContext medicalRecordDbContext)
        {
            _medicalRecordDbContext = medicalRecordDbContext;
        }
        public async Task<MedicalRecord> AddMedicalRecordAsync(MedicalRecord record)
        {
            var newMedicalRecord = _medicalRecordDbContext.MedicalRecords.Add(record).Entity;
            await _medicalRecordDbContext.SaveChangesAsync();
            return newMedicalRecord;
        }

        public Task<List<MedicalRecord>> GetAllMedicalRecordAsync()
        {
            var records = _medicalRecordDbContext.MedicalRecords.ToListAsync();
            return records;
        }

        public Task<MedicalRecord?>?GetMedicalRecordByIdAsync(Guid id)
        {
            var currentUser = _medicalRecordDbContext.MedicalRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (currentUser == null)
            {
                return null;
            }
            return currentUser;
        }

        public async Task<MedicalRecord?> UpdateMedicalRecordAsync(Guid id, MedicalRecord record)
        {
            var existingRecord = await _medicalRecordDbContext.MedicalRecords.FirstOrDefaultAsync(x => x.Id == record.Id);
            if(existingRecord == null)
            {
                return null;
            }

            _medicalRecordDbContext.Entry(existingRecord).CurrentValues.SetValues(record);

            await _medicalRecordDbContext.SaveChangesAsync();

            return existingRecord;
        }
    }
}
