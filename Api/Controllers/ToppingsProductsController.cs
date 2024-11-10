using Core.Domain.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/toppingsproducts/")]
    public class ToppingsProductsController : ControllerBase
    {
        private readonly ILogger<ToppingsProductsController> _logger;
        private readonly IToppingsProductsService _toppingsProductsService;
        private readonly IProductsService _productsService;
        private readonly IToppingsService _toppingsService;

        public ToppingsProductsController(ILogger<ToppingsProductsController> logger, IToppingsProductsService toppingsProductsService,
            IProductsService productsService, IToppingsService toppingsService)
        {
            _logger = logger;
            _toppingsProductsService = toppingsProductsService;
            _productsService = productsService;
            _toppingsService = toppingsService;
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddToppingsProducts([FromForm]Guid productId, [FromForm]List<Guid> toppingIds)
        {
            _logger.LogInformation("AddToppingsProducts action method in ToppingsProductsController.");

            // Check if Product with productId exists, false if not 
            bool productExists = await _productsService.ProductExistsAsync(productId);

            // Check if Toppings in toppingIds exists, false if not
            bool[] toppingsExist = await Task.WhenAll(
                toppingIds.Select(async tId => await _toppingsService.ToppingExistsAsync(tId)));

            // If product or toppings not found, return detailed 404 response
            if (!productExists || toppingsExist.Any(b => b == false))
            {
                _logger.LogWarning($"Product or toppings not found, ProductID: {productId}");
                return Problem(
                    detail: $"Product or toppings not found, ProductID: {productId}",
                    statusCode: 404,
                    title: "Product and toppings search.");
            }

            // Try to add ToppingProduct relations, null if failed
            List<Guid>? result = await _toppingsProductsService.AddToppingsProductsAsync(productId, toppingIds);

            // If adding failed, return detailed 500 result
            if (result == null)
            {
                _logger.LogWarning("Failed to add toppings to product.");
                return Problem(
                    detail: "Failed to add toppings to product.",
                    statusCode: 500,
                    title: "Adding toppings to product.");
            }

            return Created();
        }
    }
}
