using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SollyLearn.API.Data
{
    public class SollyLearnAuthDbContext : IdentityDbContext
    {
        public SollyLearnAuthDbContext(DbContextOptions<SollyLearnAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "54da0a1a-b44f-430a-b7ab-5149ba6490e6";
            var writerRoleId = "c900ba5d-099c-42f7-b544-359773431162";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id =readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                 new IdentityRole
                {
                    Id =writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
