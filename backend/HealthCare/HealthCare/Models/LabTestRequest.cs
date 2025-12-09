namespace HealthCare.Models
{
    public class LabTestRequest
    {
        public int LabTestRequestId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TestName { get; set; } = string.Empty;
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}

