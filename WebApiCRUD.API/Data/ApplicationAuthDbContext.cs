using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiCRUD.API.Data
{
    public class ApplicationAuthDbContext : IdentityDbContext
    {
        public ApplicationAuthDbContext(DbContextOptions<ApplicationAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = Guid.Parse("c72ee27d-fdeb-4195-8329-d42460a69d19");
            var writerRoleId = Guid.Parse("e8499d4a-2d5c-4206-b19a-fd42edc438e7");

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId.ToString(),
                    ConcurrencyStamp = readerRoleId.ToString(),
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId.ToString(),
                    ConcurrencyStamp= writerRoleId.ToString(),
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
