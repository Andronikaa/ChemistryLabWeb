using Entities.Dtos;
using Entities.Models;
using Entities.RequestFeatures;
using Entities.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Data.Repositories.Interfaces
{
    public interface IBenchmarkGenerator
    {
        IEnumerable<ChemicalElementDto> GetAllChemicalElements();

        ChemicalElementDto GetChemicalElement(int id, bool trackChanges);

        Task<PagedList<Compound>> GetAllCompundsAsync(int categoryId, CompoundParams compoundParams, bool trackchanges);

        Task<CompoundDto> GetCompundAsync(int categoryId, int id,  bool trackchanges);

        Task<CompoundDto> GetCompundsByIdsAsync(int categoryId, IEnumerable<int> ids, bool trackChanges);

        Task<Compound> CreateCompundAsync(CompoundForCreationDto compoundDto, int compoundId);

        Task CreateAsync();


        Task UpdateAsync();

        Task UpdateCompoundAsync();

        Task DeleteAsync();

        Task DeleteCompoundAsync();
    }
}
