using AmazeCareHMS.DTOs.Prescriptions;
using AmazeCareHMS.Models;
using AmazeCareHMS.Data;
using AmazeCareHMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmazeCareHMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly AmazeCareDbContext _context;

        public PrescriptionController(IPrescriptionService prescriptionService, AmazeCareDbContext context)
        {
            _prescriptionService = prescriptionService;
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptionsAsync();
            return Ok(prescriptions);
        }

        [HttpGet("by-consultation/{consultationId}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetByConsultation(int consultationId)
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsByConsultationIdAsync(consultationId);
            return Ok(prescriptions);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Create(PrescriptionCreateDto dto)
        {
            var created = await _prescriptionService.CreatePrescriptionAsync(dto);
            return Ok(created);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] PrescriptionUpdateDto updatedPrescription)
        {
            if (id != updatedPrescription.PrescriptionId)
                return BadRequest("ID mismatch");

            var existing = await _context.Prescriptions.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.MedicineName = updatedPrescription.MedicineName;
            existing.Dosage = updatedPrescription.Dosage;
            existing.Timing = updatedPrescription.Timing;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }
    }
}
