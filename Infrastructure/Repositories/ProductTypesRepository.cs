using Core.Domain.Entities;
using Core.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductTypesRepository : IProductTypesRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductTypesRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        // Get all product types
        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _db.ProductTypes.ToListAsync();
        }

        // Get product type with id
        public async Task<ProductType?> GetProductTypeByIdAsync(Guid productTypeId)
        {
            return await _db.ProductTypes.FirstOrDefaultAsync(pt => pt.Id == productTypeId);
        }

        // Add a product type to the database
        public async Task AddProductTypeAsync(ProductType productType)
        {
            await _db.ProductTypes.AddAsync(productType);
        }

        // Update the existing product type with new information
        public void UpdateProductType(ProductType existingProductType, ProductType updatedProductType)
        {
            _db.Entry(existingProductType).CurrentValues.SetValues(updatedProductType);
            _db.Entry(existingProductType).State = EntityState.Modified;
        }

        // Delete a product type
        public void DeleteProductType(ProductType productType)
        {
            _db.ProductTypes.Remove(productType);
        }

        // Check if any changes were saved to the database
        public async Task<bool> IsSaved()
        {
            // How many changes are saved?
            int saved = await _db.SaveChangesAsync();

            return saved > 0;
        }
    }
}
