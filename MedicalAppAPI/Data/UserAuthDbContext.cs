using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppAPI.Data
{
    public class UserAuthDbContext : IdentityDbContext
    {
        public UserAuthDbContext(DbContextOptions<UserAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerIdentity = "26388326-ebff-4a63-a1b6-4e5f110e6ed9";
            var writerIdentity = "28946472-7dba-4fca-a675-a43a7e30f35e";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerIdentity,
                    ConcurrencyStamp = readerIdentity,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerIdentity,
                    ConcurrencyStamp = writerIdentity,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
