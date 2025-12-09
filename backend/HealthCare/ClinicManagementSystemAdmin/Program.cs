using HealthCareManagementSystem.Database;
using HealthCareManagementSystem.Helper;
using HealthCareManagementSystem.Models;
using HealthCareManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthCareManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });




            // Database Context
            builder.Services.AddDbContext<RoleDbContext>(options =>  
            {
                var connectionString = builder.Configuration.GetConnectionString("default");
                options.UseSqlServer(connectionString);
            });

            // ASP.NET Core Identity Configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>() 
                .AddEntityFrameworkStores<RoleDbContext>() 
                .AddDefaultTokenProviders();

            // Configure Identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // Repository services
            builder.Services.AddScoped<IUserRepository, UserSqlServerRepositoryImpl>();
            builder.Services.AddScoped<IRoleRepository, RoleSqlServerRepositoryImpl>();
            builder.Services.AddScoped<ISpecializationRepository, SpecializationSqlServerRepositoryImpl>();

            builder.Services.AddScoped<JwtTokenHelper>();

            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Middleware order is critical - must be in this order
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            
            // Map Identity API endpoints (login, register, etc.)
            //app.MapIdentityApi<ApplicationUser>();
            
            // Map custom controllers
            app.MapControllers();

            SeedExistingUsers(app).GetAwaiter().GetResult();

            app.Run();
        }

        private static async Task SeedExistingUsers(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RoleDbContext>();
            var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<ApplicationUser>>();

            // Known intended passwords provided by user for existing seeded accounts.
            var resetPasswords = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["sreejith.menon@hospital.com"] = "Doctor@123",
                ["anjali.jose@hospital.com"] = "Doctor@234",
                ["meera.pillai@hospital.com"] = "Recep@123",
                ["jithin.mathew@hospital.com"] = "Pharma@123",
                ["sneha.tech@hospital.com"] = "Lab@123"
            };

            var usersNeedingFix = await context.Users
                .Where(u =>
                    string.IsNullOrWhiteSpace(u.NormalizedEmail) ||
                    string.IsNullOrWhiteSpace(u.NormalizedUserName) ||
                    string.IsNullOrWhiteSpace(u.PasswordHash))
                .ToListAsync();

            var resetEmailsUpper = resetPasswords.Keys
                .Select(e => e.ToUpperInvariant())
                .ToList();

            var usersToReset = await context.Users
                .Where(u => resetEmailsUpper.Contains(u.Email.ToUpper()))
                .ToListAsync();

            var allUsers = usersNeedingFix
                .Concat(usersToReset)
                .DistinctBy(u => u.Id)
                .ToList();

            if (!allUsers.Any())
                return;

            foreach (var user in allUsers)
            {
                // Identity lookups rely on normalized fields; populate if missing.
                user.NormalizedEmail ??= user.Email?.ToUpperInvariant();
                user.NormalizedUserName ??= (user.UserName ?? user.Email)?.ToUpperInvariant();

                // Ensure required Identity stamps exist
                user.SecurityStamp ??= Guid.NewGuid().ToString();
                user.ConcurrencyStamp ??= Guid.NewGuid().ToString();

                // If a specific password is provided, reset to that value.
                if (resetPasswords.TryGetValue(user.Email, out var providedPassword))
                {
                    user.PasswordHash = passwordHasher.HashPassword(user, providedPassword);
                }
                else if (string.IsNullOrWhiteSpace(user.PasswordHash))
                {
                    // Default bootstrap password so the account is usable; should be reset after first login.
                    user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
