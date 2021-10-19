using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Data.Repositories.Interfaces
{
    public interface IBenchmarkGenerator
    {
        IEnumerable<ChemicalElementDto> GetAllChemicalElementsAsync();

        Task GetAllCompundsAsync();

        Task CreateAsync();

        Task CreateCompundAsync();

        Task UpdateAsync();

        Task UpdateCompoundAsync();

        Task DeleteAsync();

        Task DeleteCompoundAsync();
    }
}
