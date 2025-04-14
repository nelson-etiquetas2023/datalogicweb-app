using Shared.Model;

namespace Backend.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product?> CreateProductAsync(Product producto);
        Task<bool> UpdateproductAsync(Product producto);
        Task<bool> DeleteProductAsync(int id);
    }
}
