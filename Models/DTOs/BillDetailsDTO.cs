namespace HealthCare.Models.DTOs
{
    public class BillDetailsDTO
    {
        public int PharmacyBillId { get; set; }
        public DateTime BillDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public List<BillItemDTO> Items { get; set; } = new();
    }
}
