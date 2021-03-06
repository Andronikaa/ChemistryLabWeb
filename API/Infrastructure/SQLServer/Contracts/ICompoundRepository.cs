using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICompoundRepository
    {
        Task<PagedList<Compound>> GetAllCompoundsAsync(int categoryId, CompoundParams compoundParams, bool trackChanges);

        Task<Compound> GetCompoundAsync(int categoryId, int compoundId, bool trackChanges);

        Task<Compound> GetCompoundsByIdsAsync(int categoryId, IEnumerable<int> compoundIds, bool trackChanges);

        void CreateCompound(Compound compound);
    }
}
