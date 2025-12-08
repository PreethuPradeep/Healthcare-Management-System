using HealthCare.Database;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repository.BillingRepo
{
    public class BillingRepository : IBillingRepository
    {
        private readonly HealthCareDbContext _context;

        public BillingRepository(HealthCareDbContext context)
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
