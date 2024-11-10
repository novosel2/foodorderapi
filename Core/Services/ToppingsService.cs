using Core.Domain.Entities;
using Core.Dto.ToppingDto;
using Core.IRepositories;
using Core.IServices;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class ToppingsService : IToppingsService
    {
        private readonly ILogger<ToppingsService> _logger;
        private readonly IToppingsRepository _toppingsRepository;

        public ToppingsService(ILogger<ToppingsService> logger, IToppingsRepository toppingsRepository)
        {
            _logger = logger;
            _toppingsRepository = toppingsRepository;
        }


        // Get all toppings
        public async Task<List<Topping>> GetToppingsAsync()
        {
            _logger.LogInformation("GetToppingsAsync method in ToppingsService.");

            // Get toppings from repository
            List<Topping> toppings = await _toppingsRepository.GetToppingsAsync();

            return toppings;
        }

        // Get toppings based on list of ids
        public async Task<List<Topping>> GetToppingsByIdsAsync(List<Guid> toppingIds)
        {
            _logger.LogInformation("GetToppingsByIdsAsync method in ToppingsService.");

            // Get toppings from repository based on id
            List<Topping> toppings = await _toppingsRepository.GetToppingsByIdsAsync(toppingIds);

            return toppings;
        }

        // Get a topping based on id
        public async Task<Topping?> GetToppingByIdAsync(Guid toppingId)
        {
            _logger.LogInformation("GetToppingByIdAsync method in ToppingsService.");

            // Get topping by id, null if not found
            Topping? topping = await _toppingsRepository.GetToppingByIdAsync(toppingId);

            return topping;
        }

        // Add new topping
        public async Task<ToppingAddRequest?> AddToppingAsync(ToppingAddRequest topping)
        {
            _logger.LogInformation("AddToppingAsync method in ToppingsService.");

            // Try to add topping
            await _toppingsRepository.AddToppingAsync(topping.ToTopping());

            // Check if any changes are saved, return null if not
            if (! await _toppingsRepository.IsSaved())
            {
                return null;
            }

            return topping;
        }

        // Delete a topping
        public async Task<Topping?> DeleteToppingAsync(Topping topping)
        {
            _logger.LogInformation("DeleteToppingAsync method in ToppingsService.");

            // Try to delete topping
            _toppingsRepository.DeleteTopping(topping);

            // Check if any changes are saved, return null if not
            if (! await _toppingsRepository.IsSaved())
            {
                return null;
            }

            return topping;
        }

        // Check if topping exists
        public Task<bool> ToppingExistsAsync(Guid toppingId)
        {
            _logger.LogInformation("ToppingExistsAsync method in ToppingsService.");

            return _toppingsRepository.ToppingExistsAsync(toppingId);
        }
    }
}
