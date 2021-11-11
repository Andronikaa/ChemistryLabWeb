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

        public IEnumerable<Compound> GetAllCompounds(int categoryId, bool trackChanges)
        {
            return FindByCondition(c => c.CompoundCategory.Id.Equals(categoryId), trackChanges)
             .OrderBy(c => c.Name);
        }

        public Compound GetCompound(int categoryId, int compoundId, bool trackChanges)
        {
            return FindByCondition(c => c.CompoundCategory.Id.Equals(categoryId) && c.Id.Equals(compoundId), trackChanges)
                    .SingleOrDefault();
        }

        public Compound GetCompoundsByIds(int categoryId, IEnumerable<int> compoundIds, bool trackChanges)
        {
            return FindByCondition(c => c.CompoundCategory.Id.Equals(categoryId) && compoundIds.Contains(c.Id), trackChanges)
                    .SingleOrDefault();
        }

        public void CreateCompound(Compound compound)
        {
            Create(compound);
        }
    }
}
