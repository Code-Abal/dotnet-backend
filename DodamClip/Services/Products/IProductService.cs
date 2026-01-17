using DodamClip.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DodamClip.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductDto dto);
        Task UpdateAsync(int id, ProductDto dto);
        Task DeleteAsync(int id);
    }
}