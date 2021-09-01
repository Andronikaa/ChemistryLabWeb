using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbBased.API.Models.Dto
{
    public class PagedStructuresDto
    {
        public int Pages { get; set; }

        public IEnumerable<Structure> Structures { get; set; }
    }
}
