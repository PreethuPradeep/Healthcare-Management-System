using HealthCareManagementSystem.Models;

namespace HealthCareManagementSystem.Repository
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<Specialization>> GetAllActiveSpecializationsAsync();
        Task<Specialization?> GetSpecializationByIdAsync(int id);
        Task<int> AddSpecializationAsync(Specialization specialization);
        Task<int> UpdateSpecializationAsync(Specialization specialization);
        Task<int> DeactivateSpecializationAsync(int id);
    }
}
