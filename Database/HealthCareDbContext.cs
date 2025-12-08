using HealthCare.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Database
{
    public class HealthCareDbContext : IdentityDbContext<User, Role, int>
    {
        public HealthCareDbContext(DbContextOptions<HealthCareDbContext> options)
            : base(options)
        {
        }

        //  GROUP COMMON MODELS
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        //  PHARMACIST MODULE MODELS
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<MedicinePrescriptionDetails> MedicinePrescriptionDetails { get; set; }
        public DbSet<PharmacyBill> PharmacyBills { get; set; }
        public DbSet<PharmacyBillItem> PharmacyBillItems { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // RELATIONSHIPS THAT DO NOT REQUIRE MODIFYING GROUP MODELS

            // PharmacyBill → BillItems (1 → Many)
            modelBuilder.Entity<PharmacyBill>()
                .HasMany(b => b.Items)
                .WithOne(i => i.PharmacyBill)
                .HasForeignKey(i => i.PharmacyBillId);

            // Medicine → BillItems (1 → Many)
            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.BillItems)
                .WithOne(bi => bi.Medicine)
                .HasForeignKey(bi => bi.MedicineId);

            // Medicine → StockTransactions (1 → Many)
            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.StockTransactions)
                .WithOne(st => st.Medicine)
                .HasForeignKey(st => st.MedicineId);

            
        }
    }
}
