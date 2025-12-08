namespace HealthCare.Models.DTOs
{
    public class BillCreateDTO
    {
        public List<BillItemCreateDTO> Items { get; set; } = new();
    }

    public class BillItemCreateDTO
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
    }
}
