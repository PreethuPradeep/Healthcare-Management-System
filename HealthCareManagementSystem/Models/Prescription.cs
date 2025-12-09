namespace HealthCareManagementSystem.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int ConsulationId { get; set; }
        public string MedicineName { get; set; }
    }
}
