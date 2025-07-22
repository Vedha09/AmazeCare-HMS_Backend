using AmazeCareHMS.Data;
using AmazeCareHMS.DTOs.Appointments;
using AmazeCareHMS.Models;
using AmazeCareHMS.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazeCareHMS.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AmazeCareDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(AmazeCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            return appointment == null ? null : _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentCreateDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<bool> UpdateAppointmentAsync(int id, AppointmentUpdateDto dto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            _mapper.Map(dto, appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
