using HealthCareManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionRepository _repo;

        public PrescriptionsController(IPrescriptionRepository repo)
        {
            _repo = repo;
        }

        // ✅ 1. Search Prescriptions (by keyword)
        // keyword can be Patient Name / MMR / AppointmentId (as your repo supports)
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Search keyword is required");

            var result = await _repo.SearchByPatientOrDoctorAsync(keyword);
            return Ok(result);
        }

        // ✅ 2. Get Prescription Basic Info
        [HttpGet("{prescriptionId}")]
        public async Task<IActionResult> GetPrescription(int prescriptionId)
        {
            var prescription = await _repo.GetPrescriptionAsync(prescriptionId);
            if (prescription == null)
                return NotFound("Prescription not found");

            return Ok(prescription);
        }

        // ✅ 3. Get Prescription Medicines
        [HttpGet("{prescriptionId}/items")]
        public async Task<IActionResult> GetPrescriptionItems(int prescriptionId)
        {
            var items = await _repo.GetPrescriptionItemsAsync(prescriptionId);
            return Ok(items);
        }

        // ✅ 4. Get Dosage Details
        [HttpGet("{prescriptionId}/dosage")]
        public async Task<IActionResult> GetDosageDetails(int prescriptionId)
        {
            var dosage = await _repo.GetDosageDetailsAsync(prescriptionId);
            return Ok(dosage);
        }
    }
}
