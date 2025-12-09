using HealthCare.Database;
using HealthCareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem.Repository
{
    public class RoleSqlServerRepositoryImpl : IRoleRepository
    {
        private readonly HealthCareDbContext _context;

        public RoleSqlServerRepositoryImpl(HealthCareDbContext context)
        {
            _context = context;
        }

        // Get only active roles
        public async Task<IEnumerable<Role>> GetAllActiveRolesAsync()
        {
            return await _context.Roles
                .Where(r => r.IsActive == true)
                .ToListAsync();
        }

        // Get single role by ID
        public async Task<Role?> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        // Add a new role
        public async Task<int> AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            return await _context.SaveChangesAsync();
        }

        // Update existing role
        public async Task<int> UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            return await _context.SaveChangesAsync();
        }

        // Soft delete: deactivate role
        public async Task<int> DeactivateRoleAsync(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);

            if (role == null)
                return 0;

            role.IsActive = false;
            _context.Roles.Update(role);

            return await _context.SaveChangesAsync();
        }
    }
}
