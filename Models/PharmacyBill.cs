using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class PharmacyBill
    {
        [Key]
        public int PharmacyBillId { get; set; }

        public DateTime BillDate { get; set; } = DateTime.Now;

        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        // Navigation
        public ICollection<PharmacyBillItem>? Items { get; set; }
    }
}
