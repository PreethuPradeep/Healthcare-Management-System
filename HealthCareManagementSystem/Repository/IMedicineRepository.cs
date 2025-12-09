using HealthCareManagementSystem.Models;

namespace HealthCareManagementSystem.Repository
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task<Medicine?> GetByIdAsync(int id);
        Task<Medicine> AddAsync(Medicine medicine);
        Task<Medicine> UpdateAsync(Medicine medicine);
        Task<bool> DeleteAsync(int id);

        // Stock operations
        Task<bool> CheckStockAsync(int medicineId, int requiredQty);
        Task<bool> ReduceStockAsync(int medicineId, int quantity);
    }
}
