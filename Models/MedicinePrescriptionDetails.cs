using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class MedicinePrescriptionDetails
    {
        [Key]
        public int MedPrescDetId { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }

        [Required]
        [StringLength(20)]
        public string MealTime { get; set; } = string.Empty;

        public int MorningDose { get; set; }
        public int NoonDose { get; set; }
        public int EveningDose { get; set; }

        public int? Quantity { get; set; }
        public int? Dosage { get; set; }

        public int DurationInDays { get; set; }
    }
}
