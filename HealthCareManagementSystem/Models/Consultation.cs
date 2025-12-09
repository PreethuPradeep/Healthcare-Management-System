namespace HealthCareManagementSystem.Models
{
    public class Consultation
    {
        public int ConsulatationId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime DateBooked { get; set; }
        public string DoctorNotes { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string NextActions { get; set; }
    }
}
