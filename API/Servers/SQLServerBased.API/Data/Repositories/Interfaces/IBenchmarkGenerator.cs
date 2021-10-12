using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLServerBased.API.Data.Repositories.Interfaces
{
    public interface IBenchmarkGenerator
    {
        Task<IEnumerable<ChemicalElement>> GetAllAsync();

        Task GetAllCompundsAsync();

        Task CreateAsync();

        Task CreateCompundAsync();

        Task UpdateAsync();

        Task UpdateCompoundAsync();

        Task DeleteAsync();

        Task DeleteCompoundAsync();
    }
}
