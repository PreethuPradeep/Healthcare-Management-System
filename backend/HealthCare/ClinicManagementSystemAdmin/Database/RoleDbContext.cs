using HealthCareManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCareManagementSystem.Database
{
    public class RoleDbContext : IdentityDbContext<ApplicationUser>
    {
        public RoleDbContext(DbContextOptions<RoleDbContext> options) : base(options)
        {
        }
        
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Role)
                .WithMany(r => r.ApplicationUsers)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Specialization)
                .WithMany(s => s.ApplicationUsers)
                .HasForeignKey(u => u.SpecializationId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
