using HealthCare.Database;
using HealthCare.Models;
using HealthCare.Repository.BillingRepo;
using HealthCare.Repository.MedicineRepo;
using HealthCare.Repository.PrescriptionRepo;
using HealthCare.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace HealthCare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //  Add services to the container
            builder.Services.AddControllers();

            //  Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //  DbContext with LocalDB
            builder.Services.AddDbContext<HealthCareDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            //  Identity (because your DbContext inherits IdentityDbContext)
            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<HealthCareDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
            builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            builder.Services.AddScoped<IBillingRepository, BillingRepository>();


            builder.Services.AddScoped<PdfService>();


            var app = builder.Build();

            //  Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();   
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
