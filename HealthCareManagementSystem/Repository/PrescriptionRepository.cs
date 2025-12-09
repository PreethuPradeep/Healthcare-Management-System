using HealthCare.Database;
using HealthCareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HealthCareDbContext _context;

        public PrescriptionRepository(HealthCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> SearchByPatientOrDoctorAsync(string keyword)
        {
            keyword = keyword.ToLower();

            var results = await _context.Prescriptions
                .Join(_context.Patients, p => p.ConsulationId, c => c.PatientId, (p, c) => new { p, c })
                .Where(x => x.c.FullName.ToLower().Contains(keyword))
                .Select(x => x.p)
                .ToListAsync();

            return results;
        }

        public async Task<Prescription?> GetPrescriptionAsync(int prescriptionId)
        {
            return await _context.Prescriptions
                .FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionId);
        }

        public async Task<IEnumerable<PrescriptionItem>> GetPrescriptionItemsAsync(int prescriptionId)
        {
            return await _context.PrescriptionItems
                .Where(i => i.PrescriptionId == prescriptionId)
                .Include(i => i.Medicine)
                .ToListAsync();
        }

        public async Task<IEnumerable<MedicinePrescriptionDetails>> GetDosageDetailsAsync(int prescriptionId)
        {
            return await _context.MedicinePrescriptionDetails
                .Where(x => x.PrescriptionId == prescriptionId)
                .Include(x => x.Medicine)
                .ToListAsync();
        }
    }
}
