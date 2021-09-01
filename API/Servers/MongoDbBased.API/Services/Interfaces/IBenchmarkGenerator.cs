using MongoDbBased.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbBased.API.Services.Interfaces
{
    public interface IBenchmarkGenerator
    {
        Task CreateElementAsync();

        Task UpdateElementAsync();

        Task DeleteElementAsync();

        Task<IEnumerable<ChemicalElement>> GetAllElementsAsync();

        Task CreateCompoundAsync();

        Task UpdateCompoundAsync();

        Task DeleteCompoundAsync();

        Task<IEnumerable<Compound>> GetAllCompoundsAsync();
    }
}
