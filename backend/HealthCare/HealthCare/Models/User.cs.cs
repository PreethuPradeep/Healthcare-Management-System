using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HealthCare.Models
{
    [Table("TblUser")]
    public class User : IdentityUser<int>, IValidatableObject
    {
        [Required]
        [StringLength(150)]
        [Column("FullName")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column("Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Column("DateOfJoin")]
        public DateTime DateOfJoin { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter 10 digit mobile number")]
        [Column("MobileNumber")]
        public string MobileNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        [Column("Address")]
        public string? Address { get; set; }

        [Required]
        [Column("RoleId")]
        public int RoleId { get; set; }

        [NotMapped]
        public string? RoleName { get; set; }

        [Column("IsActive")]
        public bool IsActive { get; set; }


        public Doctor? Doctor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfJoin.Date > DateTime.UtcNow.Date)
            {
                yield return new ValidationResult("Date of join cannot be in the future.", new[] { nameof(DateOfJoin) });

            }
        }
    }
}
