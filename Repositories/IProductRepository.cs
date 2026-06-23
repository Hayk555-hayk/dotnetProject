using dotnetProject.Models;

namespace dotnetProject.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(string? search, decimal? maxPrice);
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}