using HealthCare.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Database
{
    public class ClinicManagementDbContext : DbContext
    {
        public ClinicManagementDbContext(DbContextOptions<ClinicManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Billing> Billings => Set<Billing>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Consultation> Consultations => Set<Consultation>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Specialization> Specializations => Set<Specialization>();
        public DbSet<LabTestRequest> LabTestRequests => Set<LabTestRequest>();
    }
}
