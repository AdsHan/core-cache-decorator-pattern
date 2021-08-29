using DPC.Catalog.Domain.Entities;
using DPC.Catalog.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPC.Catalog.Infrastructure.Data.Caching
{
    public class ProductRepositoryDecorator<T> : IProductRepository where T : IProductRepository

    {
        private readonly IMemoryCache _memoryCache;
        private readonly T _inner;

        public ProductRepositoryDecorator(IMemoryCache memoryCache, T inner)
        {
            _memoryCache = memoryCache;
            _inner = inner;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            var key = "GetAllAsync";
            var products = _memoryCache.Get<List<ProductModel>>(key);
            if (products == null)
            {
                products = await _inner.GetAllAsync();
                if (products != null)
                {
                    _memoryCache.Set(key, products, TimeSpan.FromMinutes(1));
                }
            }
            return products;
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            var key = $"GetAllAsync-{id}";
            var product = _memoryCache.Get<ProductModel>(key);
            if (product == null)
            {
                product = await _inner.GetByIdAsync(id);
                if (product != null)
                {
                    _memoryCache.Set(key, product, TimeSpan.FromMinutes(1));
                }
            }
            return product;
        }

        public async Task UpdateAsync(ProductModel product)
        {
            await _inner.UpdateAsync(product);
        }

        public async Task AddAsync(ProductModel product)
        {
            await _inner.AddAsync(product);
        }

        public async Task SaveAsync()
        {
            await _inner.SaveAsync();
        }
        public void Dispose()
        {
            _inner.Dispose();
        }
    }
}
