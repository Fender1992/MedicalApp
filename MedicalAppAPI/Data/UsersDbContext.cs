using MedicalAppAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace MedicalAppAPI.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the User entity
            modelBuilder.Entity<User>(ConfigureUser);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            // Other configurations for User...

            // Configure Gender to be stored as string
            builder.Property(u => u.Gender)
                   .HasConversion(
                       v => v.ToString(), // From Enum to String
                       v => (Gender)Enum.Parse(typeof(Gender), v) // From String to Enum
                   );
        }
    }
    }
