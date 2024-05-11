using MedicalAppAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppAPI.Data
{
    public class MedicalRecordDbContext: DbContext
    {
        public MedicalRecordDbContext(DbContextOptions<MedicalRecordDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<ImageUploads> Images { get; set; }

    }
}
