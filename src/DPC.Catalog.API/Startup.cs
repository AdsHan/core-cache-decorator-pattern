using DPC.Catalog.API.Configuration;
using DPC.Catalog.API.Service;
using DPC.Catalog.Infrastructure.Data.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DPC.Catalog.API
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

            services.AddApiConfiguration(Configuration);

            services.AddDependencyConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.AddDecoratorConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProductPopulateService productPopulateService)
        {

            app.UseApiConfiguration(env, productPopulateService);

            app.UseSwaggerConfiguration();

        }
    }
}
