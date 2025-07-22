using AmazeCareHMS.DTOs.Patients;
using AmazeCareHMS.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazeCareHMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // All endpoints require authentication
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        // GET: api/Patient
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<ActionResult<PatientDto>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<PatientDto>> CreatePatient(PatientRegisterDto newPatient)
        {
            var created = await _patientService.RegisterPatientAsync(newPatient);
            return CreatedAtAction(nameof(GetPatientById), new { id = created.PatientId }, created);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePatient(int id, PatientUpdateDto updatedPatient)
        {
            var result = await _patientService.UpdatePatientAsync(id, updatedPatient);
            if (result == null) return NotFound(); // ✅ Fixed here
            return NoContent();
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
