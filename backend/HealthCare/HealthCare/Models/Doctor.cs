using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Specialization")]
        public int SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }

        public decimal Fee { get; set; }
        public bool IsActive { get; set; }
    }
}
