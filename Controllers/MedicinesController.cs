using HealthCare.Models;
using HealthCare.Repository.MedicineRepo;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepository _repo;

        public MedicinesController(IMedicineRepository repo)
        {
            _repo = repo;
        }

        //  1. Get All Medicines
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicines = await _repo.GetAllAsync();
            return Ok(medicines);
        }

        //  2. Get Medicine By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicine = await _repo.GetByIdAsync(id);
            if (medicine == null)
                return NotFound("Medicine not found");

            return Ok(medicine);
        }

        //  3. Add Medicine
        [HttpPost]
        public async Task<IActionResult> Add(Medicine medicine)
        {
            var result = await _repo.AddAsync(medicine);
            return Ok(result);
        }

        //  4. Update Medicine
        [HttpPut]
        public async Task<IActionResult> Update(Medicine medicine)
        {
            var result = await _repo.UpdateAsync(medicine);
            return Ok(result);
        }

        //  5. Delete Medicine
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success)
                return NotFound("Medicine not found");

            return Ok("Medicine deleted successfully");
        }

        //  6. Check Stock
        [HttpGet("check-stock/{medicineId}/{quantity}")]
        public async Task<IActionResult> CheckStock(int medicineId, int quantity)
        {
            var status = await _repo.CheckStockAsync(medicineId, quantity);
            return Ok(status);
        }
    }
}
