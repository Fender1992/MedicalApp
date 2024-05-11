using MedicalAppAPI.Data;
using MedicalAppAPI.Models.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MiNET.Utils;

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

        public async Task<List<MedicalRecord>> GetAllMedicalRecordAsync(string? filterOn = null, string? filterQuery = null,
            int pageNumber = 1, int pageSize = 1000)
        {

            var records = _medicalRecordDbContext.MedicalRecords.AsQueryable();

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("diagnosis", StringComparison.OrdinalIgnoreCase))
                {
                    records = records.Where(x => x.Diagnosis.Contains(filterQuery));
                }

            }

            var skipRecords = (pageNumber - 1) * pageSize;

            return await records.Skip(skipRecords).Take(pageSize).ToListAsync();
        }

        public Task<MedicalRecord?>GetMedicalRecordByIdAsync(Guid id)
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
