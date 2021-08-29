using DPC.Catalog.Domain.Repositories;
using DPC.Catalog.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DPC.Catalog.Infrastructure.Data.Caching
{
    public static class DecoratorConfig
    {
        public static IServiceCollection AddDecoratorConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ProductRepository>();
            services.AddScoped<IProductRepository, ProductRepositoryDecorator<ProductRepository>>();

            return services;
        }
    }
}