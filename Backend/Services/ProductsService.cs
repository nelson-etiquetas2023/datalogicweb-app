using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Backend.Services
{
    public class ProductsService(DatalogicDbContext context) : IProductsService
    {
        public DatalogicDbContext Context { get; set; } = context;

        public async Task<List<Product>> GetProductsAsync()
        {
            return await Context.Productos.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await Context.Productos.FindAsync(id);
        }
        public async Task<Product?> CreateProductAsync(Product producto)
        {
            Context.Productos.Add(producto);
            await Context.SaveChangesAsync();
            return producto;
        }
        public async Task<bool> UpdateproductAsync(Product producto)
        {
            var exists = await Context.Productos.AnyAsync(p => p.Id  == producto.Id);
            if (!exists) return false;

            Context.Entry(producto).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var producto = await Context.Productos.FindAsync(id);
            if (producto is null) return false;

            Context.Productos.Remove(producto);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
