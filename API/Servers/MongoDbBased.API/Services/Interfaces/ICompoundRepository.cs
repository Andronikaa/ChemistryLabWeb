using MongoDbBased.API.Models;
using MongoDbBased.API.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbBased.API.Services.Interfaces
{
    public interface ICompoundRepository
    {
        IEnumerable<Structure> GetAllStructures(GetCompoundRequest getCompoundRequest);

        Task<IEnumerable<string>> GetAllCompoundNamesAsync();

        IEnumerable<string> GetCompoundGroups(string groupName);

        public int GetCompoundCount();
    }
}
