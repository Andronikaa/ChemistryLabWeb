using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICompoundRepository
    {
        Task<IEnumerable<Compound>> GetAllCompoundsAsync(int categoryId, bool trackChanges);

        Task<Compound> GetCompoundAsync(int categoryId, int compoundId, bool trackChanges);

        Task<Compound> GetCompoundsByIdsAsync(int categoryId, IEnumerable<int> compoundIds, bool trackChanges);

        void CreateCompound(Compound compound);
    }
}
