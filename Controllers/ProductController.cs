using Microsoft.AspNetCore.Mvc;
using Supplier1API.Model;
using Supplier1API.DTO;
using Supplier1API.Data;
using AutoMapper;


namespace Supplier1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : Controller
    {
        private readonly ProductRepo repo;
        private readonly IMapper mapper;

        public ProductController(ProductRepo _repo, IMapper _mapper)

        {

            repo = _repo;
            mapper = _mapper;

        }
        [HttpPost]
        public ActionResult CreateProduct(CreateProductDTO create)
        {
            try
            {
                var model = mapper.Map<Product>(create);
                if (repo.CreateProduct(model))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, UpdateProductDTO updateProductDto)
        {
            try
            {
                var productInDb = repo.GetProductByID(id);
                if (productInDb == null)
                {
                    return NotFound("Product not found.");
                }

                // Map the update DTO to the existing product
                mapper.Map(updateProductDto, productInDb);

                if (repo.UpdateProduct(productInDb))
                    return Ok("Product updated successfully.");
                else
                    return BadRequest("Unable to update the product.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var productInDb = repo.GetProductByID(id);
                if (productInDb == null)
                {
                    return NotFound("Product not found.");
                }

                if (repo.DeleteProduct(productInDb))
                {
                    return Ok("Product deleted successfully.");
                }
                else
                {
                    return StatusCode(500, "Unable to delete the product.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpGet]

        public ActionResult<IEnumerable<ReadProductDTO>> GetProducts()
        {
            try
            {
                var Products = repo.GetProducts();
                return Ok(mapper.Map<IEnumerable<ReadProductDTO>>(Products));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetbyID")]
        public ActionResult<ReadProductDTO> GetProduct(int id)
        {
            try
            {
                var product = repo.GetProductByID(id);
                if (product != null)
                    return Ok(mapper.Map<ReadProductDTO>(product));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // This Might be wrong test one vihanga

         [HttpPost("quote")]
        public ActionResult<QuoteResponseDTO> GetQuote(QuoteRequestDTO request)
        {
            try
            {
                var product = repo.GetProductByName(request.Name); 
                if (product == null)
                    return NotFound("Product not found");

                if (request.Quantity > product.Stock)
                    return BadRequest("Not enough stock available");

                var quoteResponse = new QuoteResponseDTO
                {
                    Id = product.Id,             // Assigning Id
                    Name = product.Name,         // Assigning Name
                    Price = product.Price,       // Assigning Price
                    Stock = product.Stock,       // Assigning Stock
                    TotalCost = product.Price * request.Quantity // Calculating TotalCost
                };

                return Ok(quoteResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("order")]
        public ActionResult PlaceOrder(OrderRequestDTO orderRequest)
        {
            try
            {
                var product = repo.GetProductByID(orderRequest.Id);
                if (product == null)
                    return NotFound("Product not found");

                if (product.Stock < orderRequest.Quantity)
                    return BadRequest("Insufficient stock");

                product.Stock -= orderRequest.Quantity; // Update stock
                repo.UpdateProduct(product); // Save changes

                return Ok("Order placed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}
