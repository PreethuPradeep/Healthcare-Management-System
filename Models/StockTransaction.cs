using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class StockTransaction
    {
        [Key]
        public int StockTransactionId { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineId { get; set; }
        public Medicine? Medicine { get; set; }

        public int QuantityChange { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string? Type { get; set; }
        public string? Remarks { get; set; }
    }
}
