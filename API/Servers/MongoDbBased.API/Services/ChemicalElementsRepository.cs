using MongoDB.Driver;
using MongoDbBased.API.Data;
using MongoDbBased.API.Models;
using MongoDbBased.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbBased.API.Services
{
    public class ChemicalElementsRepository : IChemicalElementsRepository
    {
        private IMongoCollection<ChemicalElement> _chemicalElements;

        public ChemicalElementsRepository(IMongoDatabase database)
        {
            _chemicalElements = database.GetCollection<ChemicalElement>(MongoCollections.CHEMISTRY_ELEMENTS);
        }

        public async Task<IEnumerable<ChemicalElement>> GetAllAsync()
        {
            return await _chemicalElements.Find(x => true).ToListAsync();
        }

        public IEnumerable<GroupedChemicalElement> GetAllGroupedAsync()
        {
            var x = _chemicalElements.Find(x => true)
                .ToEnumerable()
                .GroupBy(x => x.Group)
                .Select(el => new GroupedChemicalElement { Group = el.First().Group, ChemicalElements = el.AsEnumerable() });
            return x;
        }

        //public async Task<IEnumerable<GroupedChemicalElement>> GetAllGroupedAsync()
        //{
        //    return _chemicalElements
        //        .AsQueryable()
        //        .GroupBy(x => x.Group)
        //        .Select(el => new GroupedChemicalElement { Group = el.First().Group, ChemicalElements = el.AsEnumerable() });
        //}
    }
}
