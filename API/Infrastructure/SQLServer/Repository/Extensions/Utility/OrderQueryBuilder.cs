using Entities.Enums;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Repository.Extensions.Utility
{
    public class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(",");
            var propetyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propetyInfo.FirstOrDefault(i => i.Name.Equals(propertyFromQueryName, System.StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? SortOrder.Descending.GetDisplayName() : SortOrder.Ascending.GetDisplayName();

                orderQueryBuilder.Append($"{objectProperty.Name} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
