using AutoMapper;
using AmazeCareHMS.Models;
using AmazeCareHMS.DTOs.Auth;
using AmazeCareHMS.DTOs.Patients;
using AmazeCareHMS.DTOs.Doctors;
using AmazeCareHMS.DTOs.Appointments;
using AmazeCareHMS.DTOs.Consultations;
using AmazeCareHMS.DTOs.Prescriptions;

namespace AmazeCareHMS.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Auth
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); 
            CreateMap<User, UserDto>();

            // Patient
            CreateMap<PatientRegisterDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<Patient, PatientDto>() 
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

            // Doctor
            CreateMap<DoctorRegisterDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            CreateMap<Doctor, DoctorDto>();

            // Appointment
            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<AppointmentUpdateDto, Appointment>();    

            CreateMap<Appointment, AppointmentDto>()
    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.PatientName))
    .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.DoctorName));

            // Consultation
            CreateMap<ConsultationCreateDto, Consultation>();
            CreateMap<Consultation, ConsultationDto>();

            // Prescription
            CreateMap<PrescriptionCreateDto, Prescription>();
            CreateMap<Prescription, PrescriptionDto>();
            CreateMap<PrescriptionUpdateDto, Prescription>();
        }
    }
}
