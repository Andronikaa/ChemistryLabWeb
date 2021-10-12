using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbBased.API.Data;
using MongoDbBased.API.Data.Interfaces;
using MongoDbBased.API.Services;
using MongoDbBased.API.Services.Interfaces;

namespace MongoDbBased.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("LaboratoryPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => {});
        }

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ChemistryDatabaseSettings>(configuration.GetSection(nameof(ChemistryDatabaseSettings)));

            services.AddSingleton<IChemistryDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ChemistryDatabaseSettings>>().Value);

            services.AddSingleton<IMongoClient, MongoClient>
                (sp => new MongoClient(configuration["ChemistryDatabaseSettings:ConnectionString"]));

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(configuration["ChemistryDatabaseSettings:DatabaseName"]);
            });
        }

        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<IBenchmarkGenerator, BenchmarkGenerator>();
            services.AddScoped<IChemicalElementsRepository, ChemicalElementsRepository>();
            services.AddScoped<IMongoCompoundRepository, CompoundRepository>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }
    }
}
