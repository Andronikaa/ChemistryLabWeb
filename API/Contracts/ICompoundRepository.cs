using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICompoundRepository
    {
        IEnumerable<Compound> GetAllCompounds(bool trackChanges);
    }
}
