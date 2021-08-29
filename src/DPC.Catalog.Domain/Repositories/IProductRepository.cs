using DPC.Catalog.Domain.DomainObjects;
using DPC.Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPC.Catalog.Domain.Repositories
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(Guid id);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
    }
}