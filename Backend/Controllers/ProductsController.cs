using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductsService productsService) : ControllerBase
    {

        public IProductsService Productservice { get; set; } = productsService;

        [HttpGet]
        [Route("getproducts")]
        public async Task<ActionResult<List<Product>>> Getproducts()
        {
            return Ok(await Productservice.GetProductsAsync());
        }

        [HttpGet("buscarproducto")]
        public async Task<ActionResult<Product>> GetProductoById([FromQuery] int id) 
        {
            var producto = await Productservice.GetProductByIdAsync(id);
            return producto is null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        [Route("addproducts")]
        public async Task<ActionResult<Product>> Post(Product producto) 
        {
            var created = await Productservice.CreateProductAsync(producto);
            return CreatedAtAction(nameof(GetProductoById), new { id = created!.Id }, created);
        }

        [HttpPut("CambiarProducto")]
        public async Task<ActionResult<bool>> UpdateProduct([FromQuery] int id,[FromBody] Product producto) 
        {
            if (id != producto.Id) return BadRequest();
            var updated = await Productservice.UpdateproductAsync(producto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("BorrarProducto")]
        public async Task<ActionResult<bool>> Delete([FromQuery] int id) 
        {
            var eliminated = await Productservice.DeleteProductAsync(id);
            return eliminated ? NoContent() : NotFound();
        }
    }
}
