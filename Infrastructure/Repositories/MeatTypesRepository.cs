using Core.Domain.Entities;
using Core.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MeatTypesRepository : IMeatTypesRepository
    {
        private readonly ApplicationDbContext _db;

        public MeatTypesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get all meat types
        public async Task<List<MeatType>> GetMeatTypesAsync()
        {
            return await _db.MeatTypes.ToListAsync();
        }

        // Get meat type with id
        public async Task<MeatType?> GetMeatTypeByIdAsync(Guid meatTypeId)
        {
            return await _db.MeatTypes.FirstOrDefaultAsync(mt => mt.Id == meatTypeId);
        }

        // Add meat type to database
        public async Task AddMeatTypeAsync(MeatType meatType)
        {
            await _db.MeatTypes.AddAsync(meatType);
        }

        // Update existing meat type with new information
        public void UpdateMeatType(MeatType existingMeatType, MeatType updatedMeatType)
        {
            _db.MeatTypes.Entry(existingMeatType).CurrentValues.SetValues(updatedMeatType);
            _db.MeatTypes.Entry(existingMeatType).State = EntityState.Modified;
        }

        // Delete meat type from database
        public void DeleteMeatType(MeatType meatType)
        {
            _db.MeatTypes.Remove(meatType);
        }

        // Check if any changes are saved to database
        public async Task<bool> IsSaved()
        {
            // How many changes are saved?
            int saved = await _db.SaveChangesAsync();

            return saved > 0;
        }
    }
}
