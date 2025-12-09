namespace HealthCare.Models.DTOs
{
    public class BillItemDTO
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
