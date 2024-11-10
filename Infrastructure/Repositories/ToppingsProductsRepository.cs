using Core.Domain.Entities;
using Core.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ToppingsProductsRepository : IToppingsProductsRepository
    {
        private readonly ApplicationDbContext _db;

        public ToppingsProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        

        // Add ToppingProduct relation between specified product and topping
        public async Task AddToppingsProductsAsync(List<ToppingProduct> toppingProducts)
        {
            await _db.ToppingsProducts.AddRangeAsync(toppingProducts);
        }

        // Clear a certain product of toppings
        public async Task ClearToppingsProductsAsync(Guid productId)
        {
            await _db.ToppingsProducts.Where(tp => tp.ProductId == productId).ExecuteDeleteAsync();
            await _db.SaveChangesAsync();
        }

        // Check if any changes are saved
        public async Task<bool> IsSaved()
        {
            // How many changes are saved?
            int saved = await _db.SaveChangesAsync();

            return saved > 0;
        }
    }
}
