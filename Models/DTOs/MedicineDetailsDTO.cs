namespace HealthCare.Models.DTOs
{
    public class MedicineDetailsDTO
    {
        public int MedicineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? BatchNo { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
