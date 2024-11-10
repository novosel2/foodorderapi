using Core.Domain.Entities;
using Core.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ToppingsRepository : IToppingsRepository
    {
        private readonly ApplicationDbContext _db;

        public ToppingsRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        // Get all toppings
        public async Task<List<Topping>> GetToppingsAsync()
        {
            return await _db.Toppings.ToListAsync();
        }

        // Get toppings based on list of ids
        public async Task<List<Topping>> GetToppingsByIdsAsync(List<Guid> toppingIds)
        {
            return await _db.Toppings
                .Where(t => toppingIds.Contains(t.Id))
                .ToListAsync();
        }

        // Get topping based on id
        public async Task<Topping?> GetToppingByIdAsync(Guid toppingId)
        {
            return await _db.Toppings.FirstOrDefaultAsync(t => t.Id == toppingId);
        }

        // Add topping to database
        public async Task AddToppingAsync(Topping topping)
        {
            await _db.AddAsync(topping);
        }

        // Delete topping from database
        public void DeleteTopping(Topping topping)
        {
            _db.Toppings.Remove(topping);
        }

        // Check if topping with ToppingId exists
        public async Task<bool> ToppingExistsAsync(Guid toppingId)
        {
            return await _db.Toppings.AnyAsync(t => t.Id == toppingId);
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
