using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IChemicalElementRepository
    {
        IEnumerable<ChemicalElement> GetAll(bool trackChanges);

        ChemicalElement Get(int id, bool trackChanges);
    }
}
