using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class LaboratoryDbContext : DbContext
    {
        public LaboratoryDbContext(DbContextOptions options) : base (options) { }

        public DbSet<ChemicalElement> ChemicalElements { get; set; }

        public DbSet<Compound> Compounds { get; set; }

        public DbSet<CompoundCategory> CompoundCategories { get; set; }

    }
}
