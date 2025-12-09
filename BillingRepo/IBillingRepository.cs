using HealthCare.Models;

namespace HealthCare.Repository.BillingRepo
{
    public interface IBillingRepository
    {
        Task<PharmacyBill> CreateBillAsync(PharmacyBill bill, List<PharmacyBillItem> items);
    }
}
