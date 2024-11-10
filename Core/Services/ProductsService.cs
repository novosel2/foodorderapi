using Core.Domain.Entities;
using Core.Dto.ProductDto;
using Core.IRepositories;
using Core.IServices;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ILogger<ProductsService> _logger;
        private readonly IProductsRepository _productsRepository;

        public ProductsService(ILogger<ProductsService> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }


        // Get all products
        public async Task<List<Product>> GetProductsAsync()
        {
            _logger.LogInformation("GetProductsAsync method in ProductsService.");

            // Get the list of all products
            List<Product> products = await _productsRepository.GetProductsAsync();

            return products;
        }

        // Get product by id
        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            _logger.LogInformation("GetProductByIdAsync method in ProductsService.");

            // Get the product with an id, null if not found
            Product? product = await _productsRepository.GetProductByIdAsync(id);

            return product;
        }

        // Get products by product type id
        public async Task<List<Product>> GetProductsByTypeIdAsync(Guid productTypeId)
        {
            _logger.LogInformation("GetProductsByTypeIdAsync method in ProductsService.");

            // Get the list of products with same product type id
            List<Product> products = await _productsRepository.GetProductsByTypeIdAsync(productTypeId);

            return products;
        }

        // Get products by meat type id
        public async Task<List<Product>> GetProductsByMeatTypeIdAsync(Guid meatTypeId)
        {
            _logger.LogInformation("GetProductsByMeatTypeIdAsync method in ProductsService.");

            // Get the list of products with same meat type id
            List<Product> products = await _productsRepository.GetProductsByMeatTypeIdAsync(meatTypeId);

            return products;
        }

        // Update product
        public async Task<Product?> UpdateProductAsync(Product existingProduct, Product updatedProduct)
        {
            _logger.LogInformation("UpdateProductAsync method in ProductsService.");

            // Update the product with the new information
            _productsRepository.UpdateProduct(existingProduct, updatedProduct);

            // Try saving the changes, return null if no changes are saved
            if (! await _productsRepository.IsSavedAsync())
            {
                return null;
            }

            return updatedProduct;
        }

        // Add new product
        public async Task<ProductAddRequest?> AddProductAsync(ProductAddRequest productAddRequest)
        {
            _logger.LogInformation("AddProductAsync method in ProductsService.");

            // Try adding the product to database
            await _productsRepository.AddProductAsync(productAddRequest.ToProduct());

            // Try saving the changes, return null if no changes are saved
            if (! await _productsRepository.IsSavedAsync())
            {
                return null;
            }

            return productAddRequest;
        }

        // Delete a product
        public async Task<Product?> DeleteProductAsync(Product product)
        {
            _logger.LogInformation("DeleteProductAsync method in ProductsService.");

            // Delete the product
            _productsRepository.DeleteProduct(product);

            // Check if any changes are saved
            if (! await _productsRepository.IsSavedAsync())
            {
                return null;
            }

            return product;
        }

        // Check if product exists
        public Task<bool> ProductExistsAsync(Guid productId)
        {
            _logger.LogInformation("ProductExistsAsync method in ProductsService.");

            return _productsRepository.ProductExistsAsync(productId);
        }
    }
}
