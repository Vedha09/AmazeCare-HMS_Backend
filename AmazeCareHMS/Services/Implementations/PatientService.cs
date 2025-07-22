using AmazeCareHMS.Data;
using AmazeCareHMS.DTOs.Patients;
using AmazeCareHMS.Models;
using AmazeCareHMS.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazeCareHMS.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly AmazeCareDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(AmazeCareDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        //{
        //    var patients = await _context.Patients.ToListAsync();
        //    return _mapper.Map<IEnumerable<PatientDto>>(patients);
        //}

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients
                .Include(p => p.User) 
                .ToListAsync();

            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.User) 
                .FirstOrDefaultAsync(p => p.PatientId == id);

            return patient == null ? null : _mapper.Map<PatientDto>(patient);
        }


        //public async Task<PatientDto> GetPatientByIdAsync(int id)
        //{
        //    var patient = await _context.Patients.FindAsync(id);
        //    return patient == null ? null : _mapper.Map<PatientDto>(patient);
        //}

        //public async Task<PatientDto> RegisterPatientAsync(PatientRegisterDto registerDto)
        //{
        //    var patient = _mapper.Map<Patient>(registerDto);
        //    _context.Patients.Add(patient);
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<PatientDto>(patient);
        //}

        public async Task<PatientDto> RegisterPatientAsync(PatientRegisterDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == registerDto.Username))
                throw new Exception("Username already exists.");

            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Role = "Patient"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var patient = new Patient
            {
                PatientName = registerDto.PatientName,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                ContactNumber = registerDto.ContactNumber,
                MedicalHistory = registerDto.MedicalHistory,
                UserId = user.Id
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<PatientDto> UpdatePatientAsync(int id, PatientUpdateDto updateDto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return null;

            _mapper.Map(updateDto, patient);
            await _context.SaveChangesAsync();

            return _mapper.Map<PatientDto>(patient);
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
