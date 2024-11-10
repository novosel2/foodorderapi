using Core.Domain.Entities;
using Core.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _db;

        public OrdersRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get all orders from database
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _db.Orders
                .Include(o => o.OrderedProducts).ThenInclude(op => op.Product).ThenInclude(p => p.ToppingProducts).ThenInclude(tp => tp.Topping)
                .Include(o => o.OrderedProducts).ThenInclude(op => op.OrderedProductToppings)
                .AsSplitQuery()
                .ToListAsync();
        }

        // Add order to database
        public async Task AddOrderAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
        }

        // Add Ordered Product to database
        public async Task AddOrderedProductAsync(OrderedProduct orderedProduct)
        {
            await _db.OrderedProducts.AddAsync(orderedProduct);
        }

        // Add Ordered Product Topping to database
        public async Task AddOrderedProductToppingAsync(OrderedProductTopping orderedProductTopping)
        {
            await _db.OrderedProductToppings.AddAsync(orderedProductTopping);
        }

        // Check if any changes are saved to database
        public async Task<bool> IsSaved()
        {
            int saved = await _db.SaveChangesAsync();

            return saved > 0;
        }

        // Check how many changes are saved to database
        public async Task<int> HowManySaved()
        {
            int saved = await _db.SaveChangesAsync();

            return saved;
        }
    }
}
