using Core.Domain.Entities;

namespace Core.IRepositories
{
    public interface IToppingsProductsRepository
    {
        /// <summary>
        /// Get all ToppingProducts relations
        /// </summary>
        /// <returns>List of ToppingProducts relations</returns>
        //public Task<List<ToppingProduct>> GetToppingProductsAsync();

        /// <summary>
        /// Adds new ToppingProduct relations to the database
        /// </summary>
        /// <param name="toppingProducts">ToppingProduct relations we want to add</param>
        public Task AddToppingsProductsAsync(List<ToppingProduct> toppingProducts);

        /// <summary>
        /// Delete all ToppingsProducts for a certain product
        /// </summary>
        /// <param name="productId">Specified product where we want to clear toppings</param>
        public Task ClearToppingsProductsAsync(Guid productId);

        /// <summary>
        /// Checks if anything has been saved to the database
        /// </summary>
        /// <returns>True if saved, false if nothing was saved</returns>
        public Task<bool> IsSaved();
    }
}
