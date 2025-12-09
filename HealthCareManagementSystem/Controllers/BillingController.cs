using HealthCare.Database;
using HealthCareManagementSystem.Models;
using HealthCare.Services;
using HealthCareManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingPharmacyRepository _billingPharmacyRepo;
        private readonly IMedicineRepository _medicineRepo;
        private readonly PdfService _pdfService;
        private readonly HealthCareDbContext _context;

        //   CONSTRUCTOR (With PdfService + DbContext)
        public BillingController(
            IBillingPharmacyRepository billingPharmacyRepo,
            IMedicineRepository medicineRepo,
            PdfService pdfService,
            HealthCareDbContext context)
        {
            _billingPharmacyRepo = billingPharmacyRepo;
            _medicineRepo = medicineRepo;
            _pdfService = pdfService;
            _context = context;
        }

        //  CREATE PHARMACY BILL
        [HttpPost("create")]
        public async Task<IActionResult> CreateBill([FromBody] List<PharmacyBillItem> items)
        {
            if (items == null || items.Count == 0)
                return BadRequest("Bill items cannot be empty");

            //  STOCK VALIDATION
            foreach (var item in items)
            {
                var hasStock = await _medicineRepo.CheckStockAsync(item.MedicineId, item.Quantity);
                if (!hasStock)
                {
                    return BadRequest($"Insufficient stock for MedicineId: {item.MedicineId}");
                }

                //  AUTO LINE TOTAL
                item.LineTotal = item.Quantity * item.UnitPrice;
            }

            var bill = new PharmacyBill
            {
                BillDate = DateTime.Now
            };

            var savedBill = await _billingPharmacyRepo.CreateBillAsync(bill, items);
            return Ok(savedBill);
        }

        //  DOWNLOAD BILL AS PDF
        [HttpGet("download/{billId}")]
        public IActionResult DownloadBill(int billId)
        {
            var bill = _context.PharmacyBills
                .Where(b => b.PharmacyBillId == billId)
                .FirstOrDefault();

            if (bill == null)
                return NotFound("Bill not found");

            var pdf = _pdfService.GenerateBillPdf(bill);

            return File(pdf, "application/pdf", $"Bill_{billId}.pdf");
        }
    }
}
