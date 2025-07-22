using AmazeCareHMS.Data;
using AmazeCareHMS.DTOs.Prescriptions;
using AmazeCareHMS.Models;
using AmazeCareHMS.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazeCareHMS.Services.Implementations
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly AmazeCareDbContext _context;
        private readonly IMapper _mapper;

        public PrescriptionService(AmazeCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync()
        {
            var prescriptions = await _context.Prescriptions
                .ToListAsync();
            return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        }

        public async Task<PrescriptionDto> CreatePrescriptionAsync(PrescriptionCreateDto dto)
        {
            var consultation = await _context.Consultations
                .Include(c => c.Appointment)
                .FirstOrDefaultAsync(c => c.ConsultationId == dto.ConsultationId);

            if (consultation == null)
                throw new Exception("Consultation not found");

            var prescription = _mapper.Map<Prescription>(dto);
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            await _context.Entry(prescription)
                .Reference(p => p.Consultation)
                .Query()
                .Include(c => c.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(c => c.Appointment)
                    .ThenInclude(a => a.Doctor)
                .LoadAsync();

            return _mapper.Map<PrescriptionDto>(prescription);
        }

        public async Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByConsultationIdAsync(int consultationId)
        {
            var prescriptions = await _context.Prescriptions
                .Where(p => p.ConsultationId == consultationId)
                .Include(p => p.Consultation)
                    .ThenInclude(c => c.Appointment)
                        .ThenInclude(a => a.Patient)
                .Include(p => p.Consultation)
                    .ThenInclude(c => c.Appointment)
                        .ThenInclude(a => a.Doctor)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        }

        public async Task<PrescriptionDto> UpdatePrescriptionAsync(int id, PrescriptionUpdateDto updateDto)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null) return null;

            _mapper.Map(updateDto, prescription);
            await _context.SaveChangesAsync();

            return _mapper.Map<PrescriptionDto>(prescription);
        }
    }
}
