using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApi.Models.DTOs;

namespace MyApi.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> CreateAsync(ProductDto dto);
        Task UpdateAsync(ProductDto dto);
        Task DeleteAsync(Guid id);
    }
}
