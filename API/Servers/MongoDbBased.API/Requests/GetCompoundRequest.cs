using System.Collections.Generic;

namespace MongoDbBased.API.Requests
{
    public class GetCompoundRequest
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public List<string> CompoundGroups { get; set; }
    }
}
