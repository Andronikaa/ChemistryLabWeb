using Contracts;
using Entities;
using FluentValidation.AspNetCore;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;
using SQLServerBased.API.ActionFilters;
using SQLServerBased.API.Data.Repositories;
using SQLServerBased.API.Data.Repositories.Interfaces;
using SQLServerBased.API.Extensions;
using System.IO;
using System.Reflection;

namespace SQLServerBased.API
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
            services.SetUpVersioning();
            services.AddAutoMapper(typeof(Startup));
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            services.AddDbContext<LaboratoryDbContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("ChemistryLabDatabase")));
            services.ConfigureRepositoryManager();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IBenchmarkGenerator, BenchamarkGenerator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            }).AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            }).AddNewtonsoftJson().AddCustomCSVFormatter();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SQLServerBased.API", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "SQLServerBased.API", Version = "v2" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SQLServerBased.API v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "SQLServerBased.API v2");
                });
            }
            app.ConfigureExceptionHandler(logger);
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
