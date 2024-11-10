using Core.Domain.Entities;
using Core.Dto.ProductTypeDto;

namespace Core.IServices
{
    public interface IProductTypesService
    {
        /// <summary>
        /// Get all product types
        /// </summary>
        /// <returns>List of product types</returns>
        public Task<List<ProductType>> GetProductTypesAsync();

        /// <summary>
        /// Get product type by id
        /// </summary>
        /// <param name="productTypeId">Id of product type we want to get</param>
        /// <returns>Product type if found, otherwise null</returns>
        public Task<ProductType?> GetProductTypeByIdAsync(Guid productTypeId);

        /// <summary>
        /// Try to add a product type to the database
        /// </summary>
        /// <param name="productTypeAddRequest">Product type to add</param>
        /// <returns>Product type if added, null if not</returns>
        public Task<ProductTypeAddRequest?> AddProductTypeAsync(ProductTypeAddRequest productTypeAddRequest);

        /// <summary>
        /// Try to update existing product type with new information
        /// </summary>
        /// <param name="updatedProductType">Product type with updated information</param>
        /// <returns>Product type if saved, null if not</returns>
        public Task<ProductType?> UpdateProductTypeAsync(ProductType existingProductType, ProductType updatedProductType);

        /// <summary>
        /// Try to delete product type
        /// </summary>
        /// <param name="productType">Product type we want to delete</param>
        /// <returns>Product type if deleted, otherwise null</returns>
        public Task<ProductType?> DeleteProductTypeAsync(ProductType productType);
    }
}
