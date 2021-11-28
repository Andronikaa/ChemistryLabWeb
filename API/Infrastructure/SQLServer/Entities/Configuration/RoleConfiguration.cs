using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole 
                {
                    Name = "FullAccessUser",
                    NormalizedName = "Admin"
                }, 
                new IdentityRole 
                {
                    Name = "BasicAccessUser",
                    NormalizedName = "User"
                });
        }
    }
}
