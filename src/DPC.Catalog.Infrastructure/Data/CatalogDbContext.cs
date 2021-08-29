using DPC.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPC.Catalog.Infrastructure.Data
{
    public class CatalogDbContext : DbContext
    {

        public CatalogDbContext()
        {

        }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }

    }
}
