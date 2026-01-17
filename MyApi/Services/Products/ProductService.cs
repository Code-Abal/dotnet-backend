using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models.DTOs;
using MyApi.Models.Entities;
using MyApi.Repositories.Products;

namespace MyApi.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var p = new Product { Name = dto.Name, Description = dto.Description, Price = dto.Price };
            await _repo.AddAsync(p);
            dto.Id = p.Id;
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return;
            await _repo.DeleteAsync(p);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Description = p.Description, Price = p.Price });
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new ProductDto { Id = p.Id, Name = p.Name, Description = p.Description, Price = p.Price };
        }

        public async Task UpdateAsync(ProductDto dto)
        {
            var p = await _repo.GetByIdAsync(dto.Id);
            if (p == null) return;
            p.Name = dto.Name;
            p.Description = dto.Description;
            p.Price = dto.Price;
            await _repo.UpdateAsync(p);
        }
    }
}
