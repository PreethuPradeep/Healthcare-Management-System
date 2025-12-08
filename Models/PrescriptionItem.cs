using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class PrescriptionItem
    {
        [Key]
        public int PrescriptionItemId { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }

        public int Quantity { get; set; }
    }
}
