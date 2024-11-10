using Core.Domain.Entities;

namespace Core.IServices
{
    public interface IToppingsProductsService
    {
        /// <summary>
        /// Adds a new ToppingProduct relations to the database
        /// </summary>
        /// <param name="productId">Product we want to add toppings to</param>
        /// <param name="toppingIds">Toppings we want to add to product</param>
        /// <returns>Topping ids added to product</returns>
        public Task<List<Guid>?> AddToppingsProductsAsync(Guid productId, List<Guid> toppingIds);
    }
}
