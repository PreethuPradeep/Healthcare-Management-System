using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? BatchNo { get; set; }

        [StringLength(100)]
        public string? Manufacturer { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public decimal UnitPrice { get; set; }

        public int Stock { get; set; }

        // Navigation
        public ICollection<PharmacyBillItem>? BillItems { get; set; }
        public ICollection<StockTransaction>? StockTransactions { get; set; }
        public ICollection<MedicinePrescriptionDetails>? PrescriptionDetails { get; set; }
    }
}
