using Catalog.API.Data;
using Catalog.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogDbContext _context;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(CatalogDbContext context,ILogger<CatalogController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var products =await  _context.Products.Where(p=>p.Category==category).ToListAsync();
            return Ok(products);
        }

        [Route("[action]/{name}", Name = "GetProductByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var products = await _context.Products.Where(p=>p.Name.Contains(name)).ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var entity = await _context.Products.FindAsync(product.Id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {product.Id}, not found.");
                return NotFound();
            }
            entity.Summary = product.Summary;
            entity.Description = product.Description;
            entity.Name = product.Name;
            entity.Category = product.Category;
            entity.Price = product.Price;
            entity.ImageFile=product.ImageFile;
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
             _context.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
