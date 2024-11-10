using Core.Domain.Entities;

namespace Core.IServices
{
    public interface IMeatTypesService
    {
        /// <summary>
        /// Get all meat types
        /// </summary>
        /// <returns>List of meat types</returns>
        public Task<List<MeatType>> GetMeatTypesAsync();

        /// <summary>
        /// Get meat type by id
        /// </summary>
        /// <param name="meatTypeId">Id of meat type we want to get</param>
        /// <returns>Meat type with id, otherwise null</returns>
        public Task<MeatType?> GetMeatTypeByIdAsync(Guid meatTypeId);

        /// <summary>
        /// Add a meat type to database
        /// </summary>
        /// <param name="meatType">Meat type we want to add</param>
        /// <returns>Meat type if added, otherwise null</returns>
        public Task<MeatType?> AddMeatTypeAsync(MeatType meatType);

        /// <summary>
        /// Update existing meat type with new information
        /// </summary>
        /// <param name="existingMeatType">Meat type we want to update</param>
        /// <param name="updatedMeatType">Updated meat type with new information</param>
        /// <returns>Updated meat type if updated, otherwise null</returns>
        public Task<MeatType?> UpdateMeatTypeAsync(MeatType existingMeatType, MeatType updatedMeatType);

        /// <summary>
        /// Delete a meat type from database
        /// </summary>
        /// <param name="meatType">Meat type we want to delete</param>
        /// <returns>Deleted meat type, otherwise null</returns>
        public Task<MeatType?> DeleteMeatTypeAsync(MeatType meatType);
    }
}
