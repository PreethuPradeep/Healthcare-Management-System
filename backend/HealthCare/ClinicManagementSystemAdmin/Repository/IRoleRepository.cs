using HealthCareManagementSystem.Models;

namespace HealthCareManagementSystem.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllActiveRolesAsync();
        Task<Role?> GetRoleByIdAsync(int roleId);
        Task<int> AddRoleAsync(Role role);
        Task<int> UpdateRoleAsync(Role role);
        Task<int> DeactivateRoleAsync(int roleId);
    }
}
