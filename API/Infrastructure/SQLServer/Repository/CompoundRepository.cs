using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CompoundRepository : RepositoryBase<Compound>, ICompoundRepository
    {
        public CompoundRepository(LaboratoryDbContext laboratoryDbContext) : base(laboratoryDbContext)
        {

        }

        public async Task<PagedList<Compound>> GetAllCompoundsAsync(int categoryId, CompoundParams compoundParams, bool trackChanges)
        {
            var compounds = await FindByCondition(c => c.CompoundCategory.Id.Equals(categoryId), trackChanges)
             .OrderBy(c => c.Name).ToListAsync();

            return PagedList<Compound>
                .ToPagedList(compounds, compoundParams.PageNumber, compoundParams.PageSize);
        }

        public async Task<Compound> GetCompoundAsync(int categoryId, int compoundId, bool trackChanges)
        {
            return await FindByCondition(c => c.CompoundCategory.Id.Equals(categoryId) && c.Id.Equals(compoundId), trackChanges)
                    .SingleOrDefaultAsync();
        }

        public async Task<Compound> GetCompoundsByIdsAsync(int categoryId, IEnumerable<int> compoundIds, bool trackChanges)
        {
            return await FindByCondition(c => c.CompoundCategory.Id.Equals(categoryId) && compoundIds.Contains(c.Id), trackChanges)
                    .SingleOrDefaultAsync();
        }

        public void CreateCompound(Compound compound)
        {
            Create(compound);
        }
    }
}
