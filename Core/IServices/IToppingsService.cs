using Core.Domain.Entities;
using Core.Dto.ToppingDto;

namespace Core.IServices
{
    public interface IToppingsService
    {
        /// <summary>
        /// Get all toppings from the database
        /// </summary>
        /// <returns>List of toppings</returns>
        public Task<List<Topping>> GetToppingsAsync();

        /// <summary>
        /// Get toppings based on list of ids
        /// </summary>
        /// <param name="toppingIds">Ids of toppings we want to get</param>
        /// <returns>List of toppings based on ids</returns>
        public Task<List<Topping>> GetToppingsByIdsAsync(List<Guid> toppingIds);

        /// <summary>
        /// Get toppings based on id
        /// </summary>
        /// <param name="toppingId">Id of topping we want to get</param>
        /// <returns>Topping if found, otherwise null</returns>
        public Task<Topping?> GetToppingByIdAsync(Guid toppingId);

        /// <summary>
        /// Add topping to the database
        /// </summary>
        /// <param name="topping">Topping we want to add</param>
        /// <returns>Topping if added, otherwise null</returns>
        public Task<ToppingAddRequest?> AddToppingAsync(ToppingAddRequest topping);

        /// <summary>
        /// Delete topping from the database
        /// </summary>
        /// <param name="topping">Topping we want to delete</param>
        /// <returns>Topping if deleted, otherwise null</returns>
        public Task<Topping?> DeleteToppingAsync(Topping topping);

        /// <summary>
        /// Check if topping exists
        /// </summary>
        /// <param name="toppingId">Id we want to check</param>
        /// <returns>True if exists, false if not</returns>
        public Task<bool> ToppingExistsAsync(Guid toppingId);
    }
}
