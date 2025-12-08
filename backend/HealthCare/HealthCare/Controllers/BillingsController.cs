using HealthCare.Models;
using HealthCare.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillingsController : ControllerBase
{
    private readonly IBillingRepository _billingRepository;

    public BillingsController(IBillingRepository billingRepository)
    {
        _billingRepository = billingRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Billing>>> GetBillings()
    {
        var billings = await _billingRepository.GetAllAsync();
        return Ok(billings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Billing>> GetBilling(int id)
    {
        var billing = await _billingRepository.GetByIdAsync(id);

        if (billing == null)
        {
            return NotFound($"Billing with ID {id} not found.");
        }

        return Ok(billing);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<Billing>>> GetBillingsByPatient(int patientId)
    {
        var billings = await _billingRepository.GetByPatientAsync(patientId);
        return Ok(billings);
    }

    [HttpPost]
    public async Task<ActionResult<Billing>> CreateBilling(Billing billing)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdBilling = await _billingRepository.AddAsync(billing);
        return CreatedAtAction(nameof(GetBilling), new { id = createdBilling.BillingId }, createdBilling);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBilling(int id, Billing billing)
    {
        if (id != billing.BillingId)
        {
            return BadRequest("Billing ID mismatch.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updated = await _billingRepository.UpdateAsync(id, billing);
        if (updated == null)
        {
            return NotFound($"Billing with ID {id} not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBilling(int id)
    {
        var deleted = await _billingRepository.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound($"Billing with ID {id} not found.");
        }

        return NoContent();
    }
}
