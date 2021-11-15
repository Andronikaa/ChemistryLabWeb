using Entities.Models;
using Repository.Extensions.Utility;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class CompoundRepositoryExtension
    {
        public static IQueryable<Compound> Search(this IQueryable<Compound> compounds, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return compounds;

            return compounds.Where(c => c.Name.Contains(searchText.Trim().ToLower()));
        }

        public static IQueryable<Compound> Sort(this IQueryable<Compound> compounds, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return compounds.OrderBy(c => c.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Compound>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                compounds.OrderBy(c => c.Name);

            return compounds.OrderBy(orderQuery);
        }
    }
}
