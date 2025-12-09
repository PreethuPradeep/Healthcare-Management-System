using HealthCareManagementSystem.Database;
using HealthCareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem.Repository
{
    public class SpecializationSqlServerRepositoryImpl : ISpecializationRepository
    {
        private readonly RoleDbContext _context;

        public SpecializationSqlServerRepositoryImpl(RoleDbContext context)
        {
            _context = context;
        }

        // Get all active specializations
        public async Task<IEnumerable<Specialization>> GetAllActiveSpecializationsAsync()
        {
            return await _context.Specializations
                .Where(s => s.IsActive)
                .ToListAsync();
        }

        // Get specialization by ID
        public async Task<Specialization?> GetSpecializationByIdAsync(int id)
        {
            return await _context.Specializations
                .FirstOrDefaultAsync(s => s.SpecializationId == id && s.IsActive);
        }

        // Add new specialization
        public async Task<int> AddSpecializationAsync(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            return await _context.SaveChangesAsync();
        }

        // Update existing specialization
        public async Task<int> UpdateSpecializationAsync(Specialization specialization)
        {
            _context.Specializations.Update(specialization);
            return await _context.SaveChangesAsync();
        }

        // Soft delete (IsActive = false)
        public async Task<int> DeactivateSpecializationAsync(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);

            if (specialization == null)
                return 0;

            specialization.IsActive = false;
            _context.Specializations.Update(specialization);

            return await _context.SaveChangesAsync();
        }
    }
}
