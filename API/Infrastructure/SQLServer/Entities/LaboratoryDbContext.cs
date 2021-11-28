using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class LaboratoryDbContext : IdentityDbContext<User>
    {
        public LaboratoryDbContext(DbContextOptions options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<ChemicalElement> ChemicalElements { get; set; }

        public DbSet<Compound> Compounds { get; set; }

        public DbSet<CompoundCategory> CompoundCategories { get; set; }

    }
}
