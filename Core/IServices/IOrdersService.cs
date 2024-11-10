using Core.Domain.Entities;
using Core.Dto.OrderDto;

namespace Core.IServices
{
    public interface IOrdersService
    {
        /// <summary>
        /// Get all orders from database
        /// </summary>
        /// <returns>List of order responses</returns>
        public Task<List<OrderResponse>> GetOrdersAsync();

        /// <summary>
        /// Add order, ordered products and ordered product toppings to database
        /// </summary>
        /// <param name="orderAddRequest">Order we want to add</param>
        /// <returns>Added order</returns>
        public Task<OrderResponse> AddOrderAsync(OrderAddRequest orderAddRequest);
    }
}
