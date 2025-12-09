namespace HealthCare.Models.DTOs
{
    public class MedicineListDTO
    {
        public int MedicineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? BatchNo { get; set; }
        public string? Manufacturer { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
