using Entities.Models;
using Entities.RequestFeatures;

namespace Entities.RequestModels
{
    public class CompoundParams : RequstParams
    {
        public CompoundParams()
        {
            OrderBy = nameof(Compound.Name);
        }
        public string SearchText { get; set; }
    }
}
