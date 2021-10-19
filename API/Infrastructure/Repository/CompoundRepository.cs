using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CompoundRepository : RepositoryBase<Compound>, ICompoundRepository
    {
        public CompoundRepository(LaboratoryDbContext laboratoryDbContext) : base(laboratoryDbContext)
        {

        }

        public IEnumerable<Compound> GetAllCompounds(bool trackChanges)
        {
            return FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToList();
        }
    }
}
