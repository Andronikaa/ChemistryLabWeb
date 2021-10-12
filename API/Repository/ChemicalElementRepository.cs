using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    class ChemicalElementRepository : RepositoryBase<ChemicalElement>, IChemicalElementRepository
    {
        public ChemicalElementRepository(LaboratoryDbContext laboratoryDbContext): base(laboratoryDbContext)
        {
        }
    }
}
