using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using MongoDbBased.API.Data;
using MongoDbBased.API.Data.Interfaces;
using MongoDbBased.API.Services;
using MongoDbBased.API.Services.Interfaces;

namespace MongoDbBased.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("LaboratoryPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoDbBased.API", Version = "v1" });
            });

            services.Configure<ChemistryDatabaseSettings>(Configuration.GetSection(nameof(ChemistryDatabaseSettings)));

            services.AddSingleton<IChemistryDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ChemistryDatabaseSettings>>().Value);

            services.AddSingleton<IMongoClient, MongoClient>
                (sp => new MongoClient(Configuration["ChemistryDatabaseSettings:ConnectionString"]));

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(Configuration["ChemistryDatabaseSettings:DatabaseName"]);
            });

            services.AddScoped<IBenchmarkGenerator, BenchmarkGenerator>();
            services.AddScoped<IChemicalElementsRepository, ChemicalElementsRepository>();
            services.AddScoped<ICompoundRepository, CompoundRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDbBased.API v1"));
            }
            app.UseCors("LaboratoryPolicy");

            DataInjector.SeedDatabase(app.ApplicationServices.GetService<IChemistryDatabaseSettings>());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
