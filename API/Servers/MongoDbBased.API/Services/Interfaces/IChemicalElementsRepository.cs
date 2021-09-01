using MongoDbBased.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbBased.API.Services.Interfaces
{
    public interface IChemicalElementsRepository
    {
        Task<IEnumerable<ChemicalElement>> GetAllAsync();

        public IEnumerable<GroupedChemicalElement> GetAllGroupedAsync();
    }
}
