using HealthCareManagementSystem.Models;

namespace HealthCareManagementSystem.Repository
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> SearchByPatientOrDoctorAsync(string keyword);
        Task<Prescription?> GetPrescriptionAsync(int prescriptionId);

        Task<IEnumerable<PrescriptionItem>> GetPrescriptionItemsAsync(int prescriptionId);
        Task<IEnumerable<MedicinePrescriptionDetails>> GetDosageDetailsAsync(int prescriptionId);
    }
}
