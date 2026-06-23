using Microsoft.AspNetCore.Mvc;
using dotnetProject.Data;
using dotnetProject.Models;
using Microsoft.EntityFrameworkCore;
using dotnetProject.DTO;

namespace dotnetProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] string? search, [FromQuery] decimal? maxPrice)
    {
        var query = _context.Products.AsQueryable();

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name == search);
        }

        if(maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice);
        }

        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product is Product foundProduct ? Ok(foundProduct) : NotFound();
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

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, UpdateProductDto productDto)
    {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
        {
            return NotFound(new {message = "Product not found"});
        }

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;

        await _context.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if(product == null)
        {
            return NotFound(new {message = "Product not found"});
        }

        _context.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}