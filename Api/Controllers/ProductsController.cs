using Core.Domain.Entities;
using Core.Dto.ProductDto;
using Core.IServices;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }


        // GET: /api/products

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("GetProducts action method in ProductsController.");

            // Get list of products from the service
            List<Product> products = await _productsService.GetProductsAsync();

            // Parse those products to ProductResponse
            List<ProductResponse> productResponses = products.Select(p => p.ToProductResponse()!).ToList();

            return Ok(productResponses);
        }


        // GET: /api/products/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            _logger.LogInformation("GetProductById action method in ProductsController.");

            // Try to get product by id, null if failed
            Product? product = await _productsService.GetProductByIdAsync(id);

            // If product is null, return detailed 404 result
            if(product == null)
            {
                _logger.LogWarning($"Product not found, ID: {id}");
                return Problem(
                    detail: $"Product not found, ID: {id}",
                    statusCode: 404,
                    title: "Product search");
            }

            return Ok(product.ToProductResponse());
        }


        // GET: /api/products/types/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpGet("types/{productTypeId}")]
        public async Task<IActionResult> GetProductsByTypeId(Guid productTypeId)
        {
            _logger.LogInformation("GetProductsByTypeId action method in ProductsController.");

            // Get list of products from the service based on productTypeId
            List<Product> products = await _productsService.GetProductsByTypeIdAsync(productTypeId);

            // Parse those products to ProductResponse
            List<ProductResponse> productResponses = products.Select(p => p.ToProductResponse()!).ToList();

            return Ok(productResponses);
        }


        // GET: /api/products/meat/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpGet("meat/{meatTypeId}")]
        public async Task<IActionResult> GetProductsByMeatTypeId(Guid meatTypeId)
        {
            _logger.LogInformation("GetProductsByMeatTypeId action method in ProductsController.");

            // Get list of products from service based on meatTypeId
            List<Product> products = await _productsService.GetProductsByMeatTypeIdAsync(meatTypeId);

            // Parse those products as ProductResponse
            List<ProductResponse> productResponses = products.Select(p => p.ToProductResponse()!).ToList();

            return Ok(productResponses);
        }


        // GET: /api/products/meat-filter

        [HttpGet("meat-filter")]
        public async Task<IActionResult> GetProductsByMeatTypeIds([FromQuery]Guid productTypeId, [FromQuery]List<Guid> meatTypeIds)
        {
            _logger.LogInformation("GetProductsByMeatTypeIds action method in ProductsController.");

            // Initialize the list of products
            List<Product> products = new List<Product>();

            // Fill the products list only with products that are filtered in meatTypeIds list
            foreach(var id in meatTypeIds)
            {
                products.AddRange(
                    (await _productsService.GetProductsByMeatTypeIdAsync(id))
                    .Where(p => p.ProductTypeId == productTypeId));
            }

            return Ok(products);
        } 


        // POST: /api/products/post

        [HttpPost("post")]
        public async Task<IActionResult> AddProduct([FromForm]ProductAddRequest productAddRequest)
        {
            _logger.LogInformation("AddProductAsync action method in ProductsController.");

            // Try to add the product into database, null if failed
            ProductAddRequest? result = await _productsService.AddProductAsync(productAddRequest);

            // If adding failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to add product.");
                return Problem(
                    detail: "Failed to add product.",
                    statusCode: 500,
                    title: "Adding product.");
            }

            return Created();
        }


        // PUT: /api/products/put

        [HttpPut("put")]
        public async Task<IActionResult> UpdateProduct([FromForm]ProductUpdateRequest updatedProduct)
        {
            _logger.LogInformation("UpdateProductAsync action method in ProductsController.");

            // Try to get product by id, null if failed
            Product? existingProduct = await _productsService.GetProductByIdAsync(updatedProduct.Id);

            // If existing product is null, return detailed 404 result
            if (existingProduct == null)
            {
                _logger.LogWarning($"Product not found, ID: {updatedProduct.Id}");
                return Problem(
                    detail: $"Product not found, ID: {updatedProduct.Id}",
                    statusCode: 404,
                    title: "Product search.");
            }

            // Try to update the product with new information, null if failed
            Product? result = await _productsService.UpdateProductAsync(existingProduct, updatedProduct.ToProduct());

            // If updating failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to update the specified product.");
                return Problem(
                    detail: "Failed to update the specified product.",
                    statusCode: 500,
                    title: "Product update");
            }

            return Ok(updatedProduct);
        }


        // DELETE: /api/products/delete/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            _logger.LogInformation("DeleteProduct action method in ProductsController.");

            // Try to get product with id, null if failed
            Product? product = await _productsService.GetProductByIdAsync(productId);

            // If product not found, return detailed 404 response
            if (product == null)
            {
                _logger.LogWarning($"Product not found, ID: {productId}");
                return Problem(
                    detail: $"Product not found, ID: {productId}",
                    statusCode: 404,
                    title: "Product search.");
            }

            // Delete product, null if failed
            Product? result = await _productsService.DeleteProductAsync(product);

            // If deleting failed, return detailed 500 response
            if (result == null)
            {
                _logger.LogWarning("Failed to delete product.");
                return Problem(
                    detail: "Failed to delete product.",
                    statusCode: 500,
                    title: "Deleting product.");
            }

            return Ok();
        }
    }
}