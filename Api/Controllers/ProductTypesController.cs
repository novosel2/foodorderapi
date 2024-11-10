using Core.Domain.Entities;
using Core.Dto.ProductTypeDto;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/types")]
    public class ProductTypesController : ControllerBase
    {
        private readonly ILogger<ProductTypesController> _logger;
        private readonly IProductTypesService _productTypesService;

        public ProductTypesController(ILogger<ProductTypesController> logger, IProductTypesService productTypesService)
        {
            _logger = logger;
            _productTypesService = productTypesService;
        }


        // GET: /api/types

        [HttpGet]
        public async Task<IActionResult> GetProductTypes()
        {
            _logger.LogInformation("GetProductTypes action method in ProductTypesController.");

            // Get the list of product types
            List<ProductType> productTypes = await _productTypesService.GetProductTypesAsync();

            return Ok(productTypes);
        }


        // POST: /api/types/post

        [HttpPost("post")]
        public async Task<IActionResult> AddProductType([FromForm]ProductTypeAddRequest productTypeAddRequest)
        {
            _logger.LogInformation("AddProductType action method in ProductTypesController.");

            // Try to add new product type, null if failed
            ProductTypeAddRequest? result = await _productTypesService.AddProductTypeAsync(productTypeAddRequest);

            // If adding failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to add the product type into database.");
                return Problem(
                    detail: "Failed to add the product type into database.",
                    statusCode: 500,
                    title: "Adding product type.");
            }

            return Created();
        }


        // PUT: /api/types/put

        [HttpPut("put")]
        public async Task<IActionResult> UpdateProductType([FromForm]ProductType updatedProductType)
        {
            _logger.LogInformation("UpdateProductType action method in ProductTypesController.");

            // Try to get existing product type with id, null if failed
            ProductType? existingProductType = await _productTypesService.GetProductTypeByIdAsync(updatedProductType.Id);

            // If existing product type is not found, return detailed 404 result
            if (existingProductType == null)
            {
                _logger.LogWarning($"Product type not found, ID: {updatedProductType.Id}");
                return Problem(
                    detail: $"Product type not found, ID: {updatedProductType.Id}",
                    statusCode: 404,
                    title: "Product type search.");
            }

            // Try to update product type with new information, null if failed
            ProductType? result = await _productTypesService.UpdateProductTypeAsync(existingProductType, updatedProductType);

            // If updating failed, return detailed 500 result
            if (result == null)
            {
                _logger.LogWarning("Failed to update product with new information.");
                return Problem(
                    detail: "Failed to update product type with new information.",
                    statusCode: 500,
                    title: "Update product type.");
            }

            return Ok(result);
        }


        // DELETE: /api/types/delete/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpDelete("delete/{productTypeId}")]
        public async Task<IActionResult> DeleteTypeAsync(Guid productTypeId)
        {
            _logger.LogInformation("DeleteTypeAsync action method in ProductTypesController.");

            // Try to get product type by id, null if failed
            ProductType? productType = await _productTypesService.GetProductTypeByIdAsync(productTypeId);

            // If product type is null, return detailed 404 result
            if (productType == null) 
            {
                _logger.LogWarning($"Product type not found, ID: {productTypeId}");
                return Problem(
                    detail: $"Product type not found, ID: {productTypeId}",
                    statusCode: 404,
                    title: "Product search");
            }

            // Delete product type, null if failed
            ProductType? result = await _productTypesService.DeleteProductTypeAsync(productType);

            // If deleting failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to delete product type.");
                return Problem(
                    detail: "Failed to delete product type.",
                    statusCode: 500,
                    title: "Deleting product type");
            }

            return Ok(result);
        }
    }
}
