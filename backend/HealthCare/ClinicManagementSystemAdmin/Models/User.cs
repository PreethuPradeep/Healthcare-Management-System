using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareManagementSystem.Models
{  
    
    [Table("TblUser")]
        public class User : IValidatableObject
        {
            [Key]
            public int UserId { get; set; }

            [Required]
            [StringLength(150)]
            [RegularExpression(@"^[A-Za-z]+(?: [A-Za-z]+)*$",
                ErrorMessage = "Name must contain only letters and a single space between words.")]
            public string FullName { get; set; } = string.Empty;

            [Required]
            public string Gender { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Date)]
            public DateTime DateOfJoin { get; set; }

            [Required]
            [StringLength(15)]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter 10 digit mobile number")]
            public string MobileNumber { get; set; } = string.Empty;

            public string? Address { get; set; }

            [EmailAddress]
            public string? Email { get; set; }

            [Required]
            [StringLength(50)]
            public string UserName { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            public string? PasswordHash { get; set; }

            public int RoleId { get; set; }

            [ForeignKey(nameof(RoleId))]
            public Role? Role { get; set; }

            // Optional: Only for Doctors
            public int? SpecializationId { get; set; }

            [ForeignKey(nameof(SpecializationId))]
            public Specialization? Specialization { get; set; }

            // Consultation fee for doctors
            [Column(TypeName = "decimal(10,2)")]
            public decimal? ConsultationFee { get; set; }

            public bool IsActive { get; set; }

            [NotMapped]
            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; } = string.Empty;

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (DateOfJoin.Date > DateTime.UtcNow.Date)
                {
                    yield return new ValidationResult(
                        "Date of joining cannot be in the future.",
                        new[] { nameof(DateOfJoin) });
                }
            }
        }
}

