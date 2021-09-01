using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbBased.API.Data;
using MongoDbBased.API.Models;
using MongoDbBased.API.Requests;
using MongoDbBased.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbBased.API.Services
{
    public class CompoundRepository : ICompoundRepository
    {
        private IMongoCollection<Compound> _compounds;

        public CompoundRepository(IMongoDatabase database)
        {
            _compounds = database.GetCollection<Compound>(MongoCollections.COMPOUNDS);
        }

        public IEnumerable<Structure> GetAllStructures(GetCompoundRequest getCompoundRequest)
        {
            return _compounds.AsQueryable()
                   .SelectMany(x => x.Groups)
                   .Where(x => getCompoundRequest.CompoundGroups.Contains(x.CompoundGroupCategory))
                   .SelectMany(x => x.Structures);
                   //.Skip((getCompoundRequest.PageNumber - 1) * getCompoundRequest.PageSize)
                   //.Take(getCompoundRequest.PageSize);
        }

        public async Task<IEnumerable<string>> GetAllCompoundNamesAsync()
        {
            return await _compounds.Find(x => true).Project(x => x.Name).ToListAsync();
        }

        public IEnumerable<string> GetCompoundGroups(string groupName)
        {
            return _compounds.AsQueryable()
                   .Where(x => x.Name == groupName)
                   .SelectMany(x => x.Groups).Select(x => x.CompoundGroupCategory);
        }

        //after splitting to multiple layers this value will be mapper in a single request
        public int GetCompoundCount()
        {
            return _compounds.AsQueryable()
                    .SelectMany(x => x.Groups)
                    .SelectMany(x => x.Structures).Count();
        }
    }
}
