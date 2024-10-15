using System.ComponentModel.DataAnnotations;

namespace Supplier1API.DTO
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string? Description { get; set; }
    }
}
