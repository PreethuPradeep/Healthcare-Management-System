using HealthCareManagementSystem.Models;

namespace HealthCareManagementSystem.Repository
{
    public interface IBillingPharmacyRepository
    {
        Task<PharmacyBill> CreateBillAsync(PharmacyBill bill, List<PharmacyBillItem> items);
    }
}
