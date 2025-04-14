using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Backend.Services
{
    public class ProductsService : IProductsService
    {
        public DatalogicDbContext context { get; set; }
        public ProductsService(DatalogicDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Productos.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await context.Productos.FindAsync(id);
        }
        public async Task<Product?> CreateProductAsync(Product producto)
        {
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return producto;
        }
        public async Task<bool> UpdateproductAsync(Product producto)
        {
            var exists = await context.Productos.AnyAsync(p => p.Id  == producto.Id);
            if (!exists) return false;

            context.Entry(producto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto is null) return false;

            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
