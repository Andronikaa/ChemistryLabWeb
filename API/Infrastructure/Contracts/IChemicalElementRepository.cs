using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IChemicalElementRepository
    {
        IEnumerable<ChemicalElement> GetAll(bool trackChanges);
    }
}
