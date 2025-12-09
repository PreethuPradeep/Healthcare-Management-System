using HealthCare.Database;
using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicManagementDbContext _context;

        public AppointmentRepository(ClinicManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .AsNoTracking()
                .OrderByDescending(a => a.MyProperty)
                .ThenBy(a => a.TokenNumber)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetByPatientAsync(int patientId)
        {
            return await _context.Appointments
                .AsNoTracking()
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.MyProperty)
                .ToListAsync();
        }

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            // Generate a token number for the appointment date
            var currentMax = await _context.Appointments
                .Where(a => a.MyProperty.Date == appointment.MyProperty.Date)
                .MaxAsync(a => (int?)a.TokenNumber) ?? 0;

            appointment.TokenNumber = currentMax + 1;
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment?> UpdateAsync(int id, Appointment appointment)
        {
            var existing = await _context.Appointments.FindAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.PatientId = appointment.PatientId;
            existing.DoctorId = appointment.DoctorId;
            existing.MyProperty = appointment.MyProperty;
            existing.Status = appointment.Status;
            existing.TokenNumber = appointment.TokenNumber;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return false;
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

