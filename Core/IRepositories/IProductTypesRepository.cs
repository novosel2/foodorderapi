using Core.Domain.Entities;

namespace Core.IRepositories
{
    public interface IProductTypesRepository
    {
        /// <summary>
        /// Get all product types
        /// </summary>
        /// <returns>List of product types</returns>
        public Task<List<ProductType>> GetProductTypesAsync();

        /// <summary>
        /// Try to get a product type based on id
        /// </summary>
        /// <param name="productTypeId">Id of product type we want to get</param>
        /// <returns>Product type</returns>
        public Task<ProductType?> GetProductTypeByIdAsync(Guid productTypeId);

        /// <summary>
        /// Adds a new product type to the database
        /// </summary>
        /// <param name="productType">Product type we want to add</param>
        public Task AddProductTypeAsync(ProductType productType);

        /// <summary>
        /// Updates product type with new information
        /// </summary>
        /// <param name="existingProduct">Product type that is currently in the database</param>
        /// <param name="updatedProductType">Updated product type with new information</param>
        public void UpdateProductType(ProductType existingProduct, ProductType updatedProductType);

        /// <summary>
        /// Tries to delete a product type
        /// </summary>
        /// <param name="productType">Product type we want to delete</param>
        public void DeleteProductType(ProductType productType);

        /// <summary>
        /// Checks if anything has been saved to the database
        /// </summary>
        /// <returns>True if saved, false if nothing was saved</returns>
        public Task<bool> IsSaved();
    }
}
