using Core.Domain.Entities;

namespace Core.IRepositories
{
    public interface IMeatTypesRepository
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
        /// Add meat type to database
        /// </summary>
        /// <param name="meatType">Meat type we want to add</param>
        public Task AddMeatTypeAsync(MeatType meatType);

        /// <summary>
        /// Update existing meat type with new information
        /// </summary>
        /// <param name="existingMeatType">Existing meat type we want to update</param>
        /// <param name="updatedMeatType">Updated meat type with new information</param>
        public void UpdateMeatType(MeatType existingMeatType, MeatType updatedMeatType);

        /// <summary>
        /// Delete a meat type from database
        /// </summary>
        /// <param name="meatType">Meat type we want to delete</param>
        public void DeleteMeatType(MeatType meatType);

        /// <summary>
        /// Check if any changes are saved to database
        /// </summary>
        /// <returns>True if changes are saved, false if not</returns>
        public Task<bool> IsSaved();
    }
}
