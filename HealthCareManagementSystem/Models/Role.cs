using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HealthCareManagementSystem.Models
{
    public class Role
    {
        [Key] // Primary Key
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        // Navigation Property (One Role -> Many Users)
        [JsonIgnore]
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}
