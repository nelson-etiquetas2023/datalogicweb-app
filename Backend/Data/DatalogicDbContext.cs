using Microsoft.EntityFrameworkCore;
using Shared.Model;

namespace Backend.Data
{
    public class DatalogicDbContext(DbContextOptions<DatalogicDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Productos { get; set; }
    }
}
