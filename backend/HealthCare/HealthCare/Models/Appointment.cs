namespace HealthCare.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime MyProperty { get; set; }
        public int TokenNumber { get; set; }
        public string Status { get; set; }

    }
}
