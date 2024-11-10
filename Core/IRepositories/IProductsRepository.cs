using Core.Domain.Entities;

namespace Core.IRepositories
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Get all products from the database
        /// </summary>
        /// <returns>List of products</returns>
        public Task<List<Product>> GetProductsAsync();

        /// <summary>
        /// Get a product from the database based on the id
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
        /// Adds a product to database
        /// </summary>
        /// <param name="product">Product we want to add to the database</param>
        public Task AddProductAsync(Product product);

        /// <summary>
        /// Updates an existing product with new information
        /// </summary>
        /// <param name="product">Product with new information</param>
        public void UpdateProduct(Product existingProduct, Product updatedProduct);

        /// <summary>
        /// Delete a product from database
        /// </summary>
        /// <param name="product">Product we want to delete</param>
        public void DeleteProduct(Product product);

        /// <summary>
        /// Checks if product exists
        /// </summary>
        /// <param name="productId">Id we want to check</param>
        /// <returns>True if exists, false if not</returns>
        public Task<bool> ProductExistsAsync(Guid productId);

        /// <summary>
        /// Checks if any changes have been saved to the database
        /// </summary>
        /// <returns>True if any changes have been saved, otherwise false</returns>
        public Task<bool> IsSavedAsync();
    }
}
