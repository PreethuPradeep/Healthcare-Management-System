using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class PharmacyBillItem
    {
        [Key]
        public int PharmacyBillItemId { get; set; }

        [ForeignKey("PharmacyBill")]
        public int PharmacyBillId { get; set; }
        public PharmacyBill? PharmacyBill { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal LineTotal { get; set; }  // Quantity × UnitPrice
    }
}
