using Core.Domain.Entities;
using Core.Dto.ProductDto;

namespace Core.IServices
{
    public interface IProductsService
    {
        /// <summary>
        /// Get all products from the database
        /// </summary>
        /// <returns>A list of products</returns>
        public Task<List<Product>> GetProductsAsync();

        /// <summary>
        /// Get a product based on id
        /// </summary>
        /// <param name="id">Id of a product we want to get</param>
        /// <returns>A product or null if product is not found</returns>
        public Task<Product?> GetProductByIdAsync(Guid id);

        /// <summary>
        /// Get products by product type
        /// </summary>
        /// <param name="productTypeId">Id of a product type we want to filter</param>
        /// <returns>List of products with the same type</returns>
        public Task<List<Product>> GetProductsByTypeIdAsync(Guid productTypeId);

        /// <summary>
        /// Get products by meat type
        /// </summary>
        /// <param name="meatTypeId">Id of meat type we want to filter</param>
        /// <returns>List of products with the same meat type</returns>
        public Task<List<Product>> GetProductsByMeatTypeIdAsync(Guid meatTypeId);

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product">Product we want to add</param>
        /// <returns>A product if it was added and null if it wasn't</returns>
        public Task<ProductAddRequest?> AddProductAsync(ProductAddRequest product);

        /// <summary>
        /// Update an existing product with new information
        /// </summary>
        /// <param name="product">Product with updated information</param>
        /// <returns>An updated product if successful, otherwise null</returns>
        public Task<Product?> UpdateProductAsync(Product existingProduct, Product updatedProduct);

        /// <summary>
        /// Delete a product from database
        /// </summary>
        /// <param name="product">Product we want to delete</param>
        /// <returns>Product if deleted, otherwise null</returns>
        public Task<Product?> DeleteProductAsync(Product product);

        /// <summary>
        /// Checks if product exists
        /// </summary>
        /// <param name="productId">Id we want to check</param>
        /// <returns>True if exists, false if not</returns>
        public Task<bool> ProductExistsAsync(Guid productId);
    }
}
