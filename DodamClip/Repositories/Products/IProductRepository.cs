using DodamClip.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodamClip.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}