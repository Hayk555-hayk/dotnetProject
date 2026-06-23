using Microsoft.AspNetCore.Mvc;
using dotnetProject.Data;
using dotnetProject.Models;
using Microsoft.EntityFrameworkCore;
using dotnetProject.DTO;
using dotnetProject.Repositories;

namespace dotnetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] string? search, [FromQuery] decimal? maxPrice)
        {
            var products = await _repository.GetProducts(search, maxPrice);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound(new { message = $"Товар с Id {id} не найден" });

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description
            };

            await _repository.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, UpdateProductDto productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound(new { message = $"Товар с Id {id} не найден" });

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;

            await _repository.UpdateAsync(product);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound(new { message = $"Товар с Id {id} не найден" });

            await _repository.DeleteAsync(product);
            return NoContent();
        }
    }
}

