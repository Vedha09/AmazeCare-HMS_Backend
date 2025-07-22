using AmazeCareHMS.DTOs.Patients;

namespace AmazeCareHMS.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto> GetPatientByIdAsync(int id);
        Task<PatientDto> RegisterPatientAsync(PatientRegisterDto registerDto);
        Task<PatientDto> UpdatePatientAsync(int id, PatientUpdateDto updateDto);
        Task<bool> DeletePatientAsync(int id);
    }
}
