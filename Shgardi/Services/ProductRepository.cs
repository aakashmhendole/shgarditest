using Microsoft.EntityFrameworkCore;
using Shgardi.Data;
using Shgardi.Models;

namespace Shgardi.Services
{

    public class ProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// getting all product Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var r = await _context.Products.ToListAsync();
            return r;
        }
        /// <summary>
        /// getting Product details based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Creating new product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// updating product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// deleting a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }

}
