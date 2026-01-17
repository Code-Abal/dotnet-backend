using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DodamClip.Models.Entities;

namespace DodamClip.Repositories.Products
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
