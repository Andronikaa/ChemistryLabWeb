using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Data.Repositories.Interfaces
{
    public interface IBenchmarkGenerator
    {
        IEnumerable<ChemicalElementDto> GetAllChemicalElements();

        ChemicalElementDto GetChemicalElement(int id, bool trackChanges);

        IEnumerable<CompoundDto> GetAllCompunds(int categoryId, bool trackchanges);

        CompoundDto GetCompund(int categoryId, int id,  bool trackchanges);

        Task CreateAsync();

        Task CreateCompundAsync();

        Task UpdateAsync();

        Task UpdateCompoundAsync();

        Task DeleteAsync();

        Task DeleteCompoundAsync();
    }
}
