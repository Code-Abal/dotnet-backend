using System.ComponentModel.DataAnnotations;

namespace DodamClip.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}