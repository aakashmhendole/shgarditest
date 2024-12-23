using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shgardi.Models;
using Shgardi.Services;

namespace Shgardi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        private readonly ProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Getting all product data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var result = await _repository.GetAllProductsAsync();
            return Ok(result);

        }
        /// <summary>
        /// getting prouct details based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            return await _repository.GetProductAsync(id);
        }

        /// <summary>
        /// creating a new product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProductAsync(Product product)
        {
            await _repository.CreateProductAsync(product);
            return Ok(product);
        }
        /// <summary>
        /// updating product based on id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <summary>
        /// updating product based on id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateProductAsync(product);
            return Ok(product);
        }
        /// <summary>
        /// deleting product based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
            return Ok("Deleted successfully");
        }

    }
}
