using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    class ChemicalElementRepository : RepositoryBase<ChemicalElement>, IChemicalElementRepository
    {
        public ChemicalElementRepository(LaboratoryDbContext laboratoryDbContext): base(laboratoryDbContext)
        {
        }

        public IEnumerable<ChemicalElement> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(e => e.Name)
                .ToList();
        }

        public ChemicalElement Get(int id, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(id), trackChanges)
                .SingleOrDefault();
        }
    }
}
