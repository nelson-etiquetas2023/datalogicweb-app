using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public IProductsService productservice { get; set; }
        public ProductsController(IProductsService productsService)
        {
            this.productservice = productsService;
        }

        [HttpGet]
        [Route("getproducts")]
        public async Task<ActionResult<List<Product>>> Getproducts() 
        {
            return Ok(await productservice.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id) 
        {
            var producto = await productservice.GetProductByIdAsync(id);
            return producto is null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product producto) 
        {
            var created = await productservice.CreateProductAsync(producto);
            return CreatedAtAction(nameof(GetProductById), new { id = created!.Id }, created);
        }

        [HttpPut("id")]
        public async Task<ActionResult<bool>> Put(int id, Product producto) 
        {
            if (id != producto.Id) return BadRequest();
            var updated = await productservice.UpdateproductAsync(producto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id) 
        {
            var eliminated = await productservice.DeleteProductAsync(id);
            return eliminated ? NoContent() : NotFound();
        }

    }
}
