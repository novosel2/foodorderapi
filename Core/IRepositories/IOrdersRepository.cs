using Core.Domain.Entities;
using Core.Dto.OrderDto;

namespace Core.IRepositories
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Get all orders from database
        /// </summary>
        /// <returns>List of orders</returns>
        public Task<List<Order>> GetOrdersAsync();

        /// <summary>
        /// Add order to database
        /// </summary>
        /// <param name="order">Order we want to add</param>
        public Task AddOrderAsync(Order order);

        /// <summary>
        /// Add ordered product to database
        /// </summary>
        /// <param name="orderedProduct">Ordered product we want to add</param>
        public Task AddOrderedProductAsync(OrderedProduct orderedProduct);

        /// <summary>
        /// Add ordered product topping to database
        /// </summary>
        /// <param name="orderedProductTopping">Ordered product topping we want to add</param>
        public Task AddOrderedProductToppingAsync(OrderedProductTopping orderedProductTopping);

        /// <summary>
        /// Check if any changes are saved
        /// </summary>
        /// <returns>True if saved, false if not</returns>
        public Task<bool> IsSaved();

        /// <summary>
        /// Check how many changes are saved
        /// </summary>
        /// <returns>Number of changes saved</returns>
        public Task<int> HowManySaved();
    }
}
