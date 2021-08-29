using DPC.Catalog.API.Service;
using DPC.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DPC.Catalog.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("ProductsDB"));

            services.AddTransient<ProductPopulateService>();

            return services;
        }
    }
}