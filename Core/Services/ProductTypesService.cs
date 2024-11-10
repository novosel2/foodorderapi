using Core.Domain.Entities;
using Core.Dto.ProductTypeDto;
using Core.IRepositories;
using Core.IServices;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class ProductTypesService : IProductTypesService
    {
        private readonly ILogger<ProductTypesService> _logger;
        private readonly IProductTypesRepository _productTypesRepository;

        public ProductTypesService(ILogger<ProductTypesService> logger, IProductTypesRepository productTypesRepository)
        {
            _logger = logger;
            _productTypesRepository = productTypesRepository;
        }


        // Get all product types
        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            _logger.LogInformation("GetProductTypesAsync method in ProductTypesService.");

            // Get the list of product types
            List<ProductType> productTypes = await _productTypesRepository.GetProductTypesAsync();

            return productTypes;
        }

        // Get product type by id
        public async Task<ProductType?> GetProductTypeByIdAsync(Guid productTypeId)
        {
            _logger.LogInformation("GetProductTypeById method in ProductTypesService.");

            // Get product type, null if not found
            ProductType? productType = await _productTypesRepository.GetProductTypeByIdAsync(productTypeId);

            return productType;
        }

        // Add a product type
        public async Task<ProductTypeAddRequest?> AddProductTypeAsync(ProductTypeAddRequest productTypeAddRequest)
        {
            _logger.LogInformation("AddProductTypeAsync method in ProductTypesService.");

            // Try to add product type
            await _productTypesRepository.AddProductTypeAsync(productTypeAddRequest.ToProductType());

            // Check if it was added to database, return null if not
            if (! await _productTypesRepository.IsSaved())
            {
                return null;
            }

            return productTypeAddRequest;
        }

        // Update a product type with new information
        public async Task<ProductType?> UpdateProductTypeAsync(ProductType existingProductType, ProductType updatedProductType)
        {
            _logger.LogInformation("UpdateProductTypeAsync method in ProductTypesService.");

            // Try to update product type
            _productTypesRepository.UpdateProductType(existingProductType, updatedProductType);

            // Check if any changes were saved, otherwise null
            if (! await _productTypesRepository.IsSaved())
            {
                return null;
            }

            return updatedProductType;
        }

        // Delete a product type
        public async Task<ProductType?> DeleteProductTypeAsync(ProductType productType)
        {
            _logger.LogInformation("DeleteProductTypeAsync method in ProductTypesService.");

            // Try to delete product type
            _productTypesRepository.DeleteProductType(productType);

            // Check if any changes were saved, otherwise return null
            if (! await _productTypesRepository.IsSaved())
            {
                return null;
            }

            return productType;
        }
    }
}
