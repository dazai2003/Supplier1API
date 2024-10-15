namespace Supplier1API.DTO
{
    public class QuoteResponseDTO
    {
        public int Id { get; set; } // Product ID
        public string Name { get; set; } // Product name
        public decimal Price { get; set; } // Unit price of the product
        public int Stock { get; set; } // Available stock
        public decimal TotalCost { get; set; } // Total cost for the requested quantity
    }
}
