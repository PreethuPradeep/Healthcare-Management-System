using HealthCare.Database;
using HealthCareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem.Repository
{
    public class BillingPharmacyRepository : IBillingPharmacyRepository
    {
        private readonly HealthCareDbContext _context;

        public BillingPharmacyRepository(HealthCareDbContext context)
        {
            _context = context;
        }

        public async Task<PharmacyBill> CreateBillAsync(PharmacyBill bill, List<PharmacyBillItem> items)
        {
            bill.Items = items;

            // Calculate totals
            bill.SubTotal = items.Sum(i => i.LineTotal);
            bill.Tax = bill.SubTotal * 0.05m; // 5% GST
            bill.Total = bill.SubTotal + bill.Tax;

            _context.PharmacyBills.Add(bill);

            // Deduct stock
            foreach (var item in items)
            {
                var med = await _context.Medicines.FindAsync(item.MedicineId);
                if (med != null)
                {
                    med.Stock -= item.Quantity;
                    _context.Medicines.Update(med);
                }
            }

            await _context.SaveChangesAsync();
            return bill;
        }
    }
}
