using Core.Domain.Entities;
using Core.Dto.ToppingDto;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/toppings")]
    public class ToppingsController : ControllerBase
    {
        private readonly ILogger<ToppingsController> _logger;
        private readonly IToppingsService _toppingsService;

        public ToppingsController(ILogger<ToppingsController> logger, IToppingsService toppingsService)
        {
            _logger = logger;
            _toppingsService = toppingsService;
        }


        // GET: /api/toppings

        [HttpGet]
        public async Task<IActionResult> GetToppings()
        {
            _logger.LogInformation("GetToppings action method in ToppingsController.");

            // Get list of toppings from service
            List<Topping> toppings = await _toppingsService.GetToppingsAsync();

            // Parse those toppings as ToppingResponse
            List<ToppingResponse> toppingResponses = toppings.Select(t => t.ToToppingResponse()!).ToList();

            return Ok(toppingResponses);
        }


        // GET: /api/toppings/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToppingById(Guid id)
        {
            _logger.LogInformation("GetToppingById action method in ToppingsController.");

            // Try get topping from service, null if not found
            Topping? topping = await _toppingsService.GetToppingByIdAsync(id);

            // If topping not found, return detailed 404 result
            if (topping == null)
            {
                _logger.LogWarning($"Topping not found, ID: {id}");
                return Problem(
                    detail: $"Topping not found, ID: {id}",
                    statusCode: 404,
                    title: "Topping search");
            }

            return Ok(topping.ToToppingResponse());
        }


        // POST: /api/toppings/post

        [HttpPost("post")]
        public async Task<IActionResult> AddTopping([FromForm]ToppingAddRequest toppingAddRequest)
        {
            _logger.LogInformation("AddTopping action method in ToppingsController.");

            // Try to add topping, if null return detailed 400 response
            if (await _toppingsService.AddToppingAsync(toppingAddRequest) == null)
            {
                _logger.LogWarning("Failed to store topping in database.");
                return Problem(
                    detail: "Failed to store topping in database.",
                    statusCode: 400,
                    title: "Adding topping");
            }

            return Created();
        }


        // DELETE: /api/toppings/delete/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTopping(Guid id)
        {
            _logger.LogInformation("DeleteTopping action method in ToppingsController.");

            // Try to get topping we want to delete, null if not found
            Topping? topping = await _toppingsService.GetToppingByIdAsync(id);

            // If topping not found, return detailed 404 response
            if (topping == null)
            {
                _logger.LogWarning($"Topping not found, ID: {id}");
                return Problem(
                    detail: $"Topping not found, ID: {id}",
                    statusCode: 404,
                    title: "Topping search");
            }

            // Try to delete topping from database, null if failed
            Topping? result = await _toppingsService.DeleteToppingAsync(topping);

            // If result null, return detailed 400 response
            if (result == null)
            {
                _logger.LogWarning("Failed to delete topping.");
                return Problem(
                    detail: "Failed to delete topping.",
                    statusCode: 400,
                    title: "Delete topping.");
            }

            return Ok();
        }
    }
}
