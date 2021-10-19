using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace SQLServerBased.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
