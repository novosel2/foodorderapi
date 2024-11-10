using Core.Domain.Entities;

namespace Core.IRepositories
{
    public interface IToppingsRepository
    {
        /// <summary>
        /// Get all toppings from the database
        /// </summary>
        /// <returns>List of all toppings</returns>
        public Task<List<Topping>> GetToppingsAsync();

        /// <summary>
        /// Get toppings based on the ids
        /// </summary>
        /// <param name="toppingIds">Ids of toppings we want to get</param>
        /// <returns>List of toppings based on the ids</returns>
        public Task<List<Topping>> GetToppingsByIdsAsync(List<Guid> toppingIds);

        /// <summary>
        /// Get a topping based on the id
        /// </summary>
        /// <param name="toppingId">Id of topping we want to get</param>
        /// <returns>Topping if found, otherwise null</returns>
        public Task<Topping?> GetToppingByIdAsync(Guid toppingId);

        /// <summary>
        /// Add a topping to the database
        /// </summary>
        /// <param name="topping">Topping we want to add</param>
        public Task AddToppingAsync(Topping topping);

        /// <summary>
        /// Delete a topping from the database
        /// </summary>
        /// <param name="topping">Topping we want to delete</param>
        public void DeleteTopping(Topping topping);

        /// <summary>
        /// Check if topping exists
        /// </summary>
        /// <param name="toppingId">Id we want to check</param>
        /// <returns>True if exists, false if not</returns>
        public Task<bool> ToppingExistsAsync(Guid toppingId);

        /// <summary>
        /// Checks if any changes are saved to the database
        /// </summary>
        /// <returns>True if saved, false if not</returns>
        public Task<bool> IsSaved();
    }
}
