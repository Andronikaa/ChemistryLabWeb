using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICompoundRepository
    {
        IEnumerable<Compound> GetAllCompounds(int categoryId, bool trackChanges);
        Compound GetCompound(int categoryId, int compoundId, bool trackChanges);
    }
}
