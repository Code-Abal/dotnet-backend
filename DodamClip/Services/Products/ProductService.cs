using DodamClip.Repositories.Products;
using DodamClip.Models.DTOs;
using DodamClip.Models.Entities;

namespace DodamClip.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Description = p.Description, Price = p.Price });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new ProductDto { Id = p.Id, Name = p.Name, Description = p.Description, Price = p.Price };
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var p = new Product { Name = dto.Name, Description = dto.Description, Price = dto.Price };
            await _repo.AddAsync(p);
            dto.Id = p.Id;
            return dto;
        }

        public async Task UpdateAsync(int id, ProductDto dto)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) throw new KeyNotFoundException();
            p.Name = dto.Name;
            p.Description = dto.Description;
            p.Price = dto.Price;
            await _repo.UpdateAsync(p);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}