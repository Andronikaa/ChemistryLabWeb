using Microsoft.EntityFrameworkCore;
using SQLServerBased.API.Models;

namespace SQLServerBased.API.Data
{
    public class LaboratoryDbContext : DbContext
    {
        public LaboratoryDbContext(DbContextOptions<LaboratoryDbContext> options) : base (options) { }

        public DbSet<ChemicalElement> ChemicalElements { get; set; }

        public DbSet<Compound> Compounds { get; set; }

        public DbSet<CompoundCategory> CompoundCategories { get; set; }

    }
}
