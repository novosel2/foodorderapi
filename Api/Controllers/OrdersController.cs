using Core.Domain.Entities;
using Core.Dto.OrderDto;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrdersService _ordersService;

        public OrdersController(ILogger<OrdersController> logger, IOrdersService ordersService)
        {
            _logger = logger;
            _ordersService = ordersService;
        }


        // GET: /api/orders

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            _logger.LogInformation("GetOrders action method in OrdersController.");

            return Ok(await _ordersService.GetOrdersAsync());
        }


        // POST: /api/orders/post

        [HttpPost("post")]
        public async Task<IActionResult> AddOrder(OrderAddRequest orderAddRequest)
        {
            _logger.LogInformation($"AddOrder action method in OrdersController.");

            return Ok(await _ordersService.AddOrderAsync(orderAddRequest));
        }


        // DELETE: /api/orders/delete/65d375c4-2a7f-4e35-bd78-2d0dd870e97d

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            _logger.LogInformation("DeleteOrder action method in OrdersController.");

            throw new NotImplementedException();
        }
    }
}
