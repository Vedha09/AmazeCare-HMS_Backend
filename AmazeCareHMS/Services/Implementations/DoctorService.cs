using AmazeCareHMS.Data;
using AmazeCareHMS.DTOs.Doctors;
using AmazeCareHMS.Models;
using AmazeCareHMS.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazeCareHMS.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly AmazeCareDbContext _context;
        private readonly IMapper _mapper;

        public DoctorService(AmazeCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors.Include(d => d.User).ToListAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto?> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.Include(d => d.User).FirstOrDefaultAsync(d => d.DoctorId == id);
            return doctor == null ? null : _mapper.Map<DoctorDto>(doctor);
        }


        public async Task<DoctorDto?> RegisterDoctorAsync(DoctorRegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                return null;

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Doctor"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var doctor = new Doctor
            {
                DoctorName = dto.DoctorName,
                Specialty = dto.Specialty,
                Experience = dto.Experience,
                Qualification = dto.Qualification,
                Designation = dto.Designation,
                UserId = user.Id
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<bool> UpdateDoctorAsync(int id, DoctorUpdateDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return false;

            _mapper.Map(dto, doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
