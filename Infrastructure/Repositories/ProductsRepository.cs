using Core.Domain.Entities;
using Core.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        // Get all products
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _db.Products
                .Include(p => p.ProductType)
                .Include(p => p.MeatType)
                .Include(p => p.ToppingProducts)!.ThenInclude(tp => tp.Topping)
                .AsSplitQuery()
                .ToListAsync();

            return products;
        }

        // Get product based on id
        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _db.Products
                .Include(p => p.ProductType)
                .Include(p => p.MeatType)
                .Include(p => p.ToppingProducts)!.ThenInclude(tp => tp.Topping)
                .AsSplitQuery()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Get products based on product type id
        public async Task<List<Product>> GetProductsByTypeIdAsync(Guid productTypeId)
        {
            return await _db.Products
                .Include(p => p.ProductType)
                .Include(p => p.MeatType)
                .Include(p => p.ToppingProducts).ThenInclude(tp => tp.Topping)
                .AsSplitQuery()
                .Where(p => p.ProductTypeId == productTypeId)
                .ToListAsync();
        }

        // Get products based on meat type id
        public async Task<List<Product>> GetProductsByMeatTypeIdAsync(Guid meatTypeId)
        {
            return await _db.Products
                .Include(p => p.ProductType)
                .Include(p => p.MeatType)
                .Include(p => p.ToppingProducts)!.ThenInclude(tp => tp.Topping)
                .AsSplitQuery()
                .Where(p => p.MeatTypeId == meatTypeId)
                .ToListAsync();
        }

        // Add product to the database
        public async Task AddProductAsync(Product product)
        {
            await _db.Products.AddAsync(product);
        }

        // Update an existing product in the database
        public void UpdateProduct(Product existingProduct, Product updatedProduct)
        {
            _db.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
            _db.Entry(existingProduct).State = EntityState.Modified;
        }

        // Delete a product from database
        public void DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
        }

        // Check if product with id exists
        public async Task<bool> ProductExistsAsync(Guid productId)
        {
            return await _db.Products.AnyAsync(p => p.Id == productId);
        }

        // Check if any changes are saved
        public async Task<bool> IsSavedAsync()
        {
            // How many changes are saved
            int saved = await _db.SaveChangesAsync();

            return saved > 0;
        }
    }
}
