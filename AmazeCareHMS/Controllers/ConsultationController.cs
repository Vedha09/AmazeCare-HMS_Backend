using AmazeCareHMS.DTOs.Consultations;
using AmazeCareHMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AmazeCareHMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAll()
        {
            var consultations = await _consultationService.GetAllConsultationsAsync();
            return Ok(consultations);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Get(int id)
        {
            var consultation = await _consultationService.GetConsultationByIdAsync(id);
            if (consultation == null)
                return NotFound();

            return Ok(consultation);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Create(ConsultationCreateDto dto)
        {
            var created = await _consultationService.CreateConsultationAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.ConsultationId }, created);
        }
    }
}
