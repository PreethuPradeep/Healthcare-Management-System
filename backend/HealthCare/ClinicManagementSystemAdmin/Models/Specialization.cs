using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCareManagementSystem.Models
{
    [Table("TblSpecialization")]
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }

        [Required]
        [StringLength(100)]
        public string SpecializationName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        // Navigation Property (One Specialization -> Many Users/Doctors)
        [JsonIgnore]
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
