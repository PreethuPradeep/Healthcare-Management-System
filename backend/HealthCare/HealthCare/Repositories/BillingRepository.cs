using HealthCare.Database;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ClinicManagementDbContext _context;

        public BillingRepository(ClinicManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Billing>> GetAllAsync()
        {
            return await _context.Billings
                .AsNoTracking()
                .OrderByDescending(b => b.BillingDate)
                .ToListAsync();
        }

        public async Task<Billing?> GetByIdAsync(int id)
        {
            return await _context.Billings.FindAsync(id);
        }

        public async Task<IEnumerable<Billing>> GetByPatientAsync(int patientId)
        {
            return await _context.Billings
                .AsNoTracking()
                .Where(b => b.PatientId == patientId)
                .OrderByDescending(b => b.BillingDate)
                .ToListAsync();
        }

        public async Task<Billing> AddAsync(Billing billing)
        {
            billing.BillingDate = DateTime.UtcNow;
            _context.Billings.Add(billing);
            await _context.SaveChangesAsync();
            return billing;
        }

        public async Task<Billing?> UpdateAsync(int id, Billing billing)
        {
            var existing = await _context.Billings.FindAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.PatientId = billing.PatientId;
            existing.AppointmentId = billing.AppointmentId;
            existing.Amount = billing.Amount;
            existing.Description = billing.Description;
            existing.Status = billing.Status;
            existing.BillingDate = billing.BillingDate;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var billing = await _context.Billings.FindAsync(id);
            if (billing == null)
            {
                return false;
            }

            _context.Billings.Remove(billing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
