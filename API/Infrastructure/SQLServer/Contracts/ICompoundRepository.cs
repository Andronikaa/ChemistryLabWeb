using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICompoundRepository
    {
        IEnumerable<Compound> GetAllCompounds(int categoryId, bool trackChanges);

        Compound GetCompound(int categoryId, int compoundId, bool trackChanges);

        Compound GetCompoundsByIds(int categoryId, IEnumerable<int> compoundIds, bool trackChanges);

        void CreateCompound(Compound compound);
    }
}
