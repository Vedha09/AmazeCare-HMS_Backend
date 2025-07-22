using AmazeCareHMS.DTOs.Doctors;

namespace AmazeCareHMS.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> GetDoctorByIdAsync(int id);
        Task<DoctorDto?> RegisterDoctorAsync(DoctorRegisterDto dto);
        Task<bool> UpdateDoctorAsync(int id, DoctorUpdateDto dto);
        Task<bool> DeleteDoctorAsync(int id);
    }
}