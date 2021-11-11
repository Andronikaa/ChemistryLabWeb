using Entities.Dtos;
using Entities.Models;
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

        CompoundDto GetCompundsByIds(int categoryId, IEnumerable<int> ids, bool trackChanges);

        Compound CreateCompund(CompoundForCreationDto compoundDto, int compoundId);

        Task CreateAsync();


        Task UpdateAsync();

        Task UpdateCompoundAsync();

        Task DeleteAsync();

        Task DeleteCompoundAsync();
    }
}
