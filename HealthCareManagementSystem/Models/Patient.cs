using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCareManagementSystem.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [StringLength(10)]
        public string MMRNumber { get; set; } = string.Empty; // Auto-generated on create

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, ErrorMessage = "Full Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full Name can only contain letters and spaces")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(10)]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        [NotMapped]
        public int Age
        {
            get
            {
                if (DOB.HasValue)
                {
                    var today = DateTime.Today;
                    var age = today.Year - DOB.Value.Year;
                    if (DOB.Value.Date > today.AddYears(-age))
                    {
                        age--;
                    }

                    return age;
                }

                return 0;
            }
        }

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? Membership { get; set; }

        public int? MembershipId { get; set; }

        public bool IsActive { get; set; } = true;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime? DOB { get; set; }

        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        [JsonIgnore]
        public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();
    }
}

