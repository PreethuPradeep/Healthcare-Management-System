using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    [Table("TblRole")]
    public class Role:IdentityRole<int>
    {
        public bool IsActive { get; set; }
    }
}
