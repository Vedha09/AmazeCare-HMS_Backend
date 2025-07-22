using AmazeCareHMS.Data;
using AmazeCareHMS.DTOs.Consultations;
using AmazeCareHMS.Models;
using AmazeCareHMS.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazeCareHMS.Services.Implementations
{
    public class ConsultationService : IConsultationService
    {
        private readonly AmazeCareDbContext _context;
        private readonly IMapper _mapper;

        public ConsultationService(AmazeCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultationDto>> GetAllConsultationsAsync()
        {
            var consultations = await _context.Consultations
                .Include(c => c.Appointment)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ConsultationDto>>(consultations);
        }

        public async Task<ConsultationDto> GetConsultationByIdAsync(int id)
        {
            var consultation = await _context.Consultations
                .Include(c => c.Appointment)
                .FirstOrDefaultAsync(c => c.ConsultationId == id);

            return consultation == null ? null : _mapper.Map<ConsultationDto>(consultation);
        }

        public async Task<ConsultationDto> CreateConsultationAsync(ConsultationCreateDto dto)
        {
            var consultation = _mapper.Map<Consultation>(dto);
            _context.Consultations.Add(consultation);
            await _context.SaveChangesAsync();

            return _mapper.Map<ConsultationDto>(consultation);
        }
    }
}
