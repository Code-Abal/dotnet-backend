using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApi.Models.Entities;

namespace MyApi.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
