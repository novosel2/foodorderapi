using Core.Domain.Entities;
using Core.IRepositories;
using Core.IServices;
using Microsoft.Extensions.Logging;

namespace Core.Services
{
    public class MeatTypesService : IMeatTypesService
    {
        private readonly ILogger<MeatTypesService> _logger;
        private readonly IMeatTypesRepository _meatTypesRepository;

        public MeatTypesService(ILogger<MeatTypesService> logger, IMeatTypesRepository meatTypesRepository)
        {
            _logger = logger;
            _meatTypesRepository = meatTypesRepository;
        }


        // Get all meat types
        public async Task<List<MeatType>> GetMeatTypesAsync()
        {
            _logger.LogInformation("GetMeatTypesAsync method in ProductsService.");

            // Get the list of meat types
            List<MeatType> meatTypes = await _meatTypesRepository.GetMeatTypesAsync();

            return meatTypes;
        }

        // Get meat type with id
        public async Task<MeatType?> GetMeatTypeByIdAsync(Guid meatTypeId)
        {
            _logger.LogInformation("GetMeatTypeByIdAsync method in MeatTypesService.");
            
            // Get meat type with id, null if failed
            MeatType? meatType = await _meatTypesRepository.GetMeatTypeByIdAsync(meatTypeId);

            return meatType;
        }
        
        // Add meat type to database
        public async Task<MeatType?> AddMeatTypeAsync(MeatType meatType)
        {
            _logger.LogInformation("AddMeatType method in MeatTypesService.");

            // Try to add meat type
            await _meatTypesRepository.AddMeatTypeAsync(meatType);

            // Check if any changes are saved
            if (! await _meatTypesRepository.IsSaved())
            {
                return null;
            }

            return meatType;
        }

        // Update meat type with new information
        public async Task<MeatType?> UpdateMeatTypeAsync(MeatType existingMeatType, MeatType updatedMeatType)
        {
            _logger.LogInformation("UpdateMeatTypeAsync method in MeatTypesService.");

            // Try to update existing meat type
            _meatTypesRepository.UpdateMeatType(existingMeatType, updatedMeatType);

            // Check if any changes are saved
            if (! await _meatTypesRepository.IsSaved())
            {
                return null;
            }

            return updatedMeatType;
        }

        // Delete meat type from database
        public async Task<MeatType?> DeleteMeatTypeAsync(MeatType meatType)
        {
            _logger.LogInformation("DeleteMeatTypeAsync method in MeatTypesService.");

            // Try to delete meat type
            _meatTypesRepository.DeleteMeatType(meatType);

            // Check if any changes are saved
            if (! await _meatTypesRepository.IsSaved())
            {
                return null;
            }

            return meatType;
        }
    }
}
