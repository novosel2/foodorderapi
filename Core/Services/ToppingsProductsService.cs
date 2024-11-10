using Core.Domain.Entities;
using Core.IRepositories;
using Core.IServices;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class ToppingsProductsService : IToppingsProductsService
    {
        private readonly ILogger<ToppingsProductsService> _logger;
        private readonly IToppingsProductsRepository _toppingsProductsRepository;

        public ToppingsProductsService(ILogger<ToppingsProductsService> logger, IToppingsProductsRepository toppingProductRepository)
        {
            _logger = logger;
            _toppingsProductsRepository = toppingProductRepository;
        }

        public async Task<List<Guid>?> AddToppingsProductsAsync(Guid productId, List<Guid> toppingIds)
        {
            _logger.LogInformation("AddToppingProductAsync method in ToppingProductService.");

            // Clear all previous toppings
            await _toppingsProductsRepository.ClearToppingsProductsAsync(productId);

            // Initialize new toppingproduct list
            var toppingProducts = new List<ToppingProduct>();

            // Try to add ToppingProduct relations
            foreach (var topping in toppingIds)
            {
                toppingProducts.Add(new ToppingProduct()
                {
                    ProductId = productId,
                    ToppingId = topping
                });
            }

            await _toppingsProductsRepository.AddToppingsProductsAsync(toppingProducts);

            // Check if any changes are saved, return null if not
            if (! await _toppingsProductsRepository.IsSaved())
            {
                return null;
            }

            return toppingIds;
        }
    }
}
