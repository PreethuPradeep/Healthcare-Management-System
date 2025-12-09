namespace HealthCare.Models.DTOs
{
    public class PrescriptionListDTO
    {
        public int PrescriptionId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime DateIssued { get; set; }
    }
}
