using AmazeCareHMS.DTOs.Appointments;

namespace AmazeCareHMS.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        Task<AppointmentDto> CreateAppointmentAsync(AppointmentCreateDto dto);
        Task<bool> UpdateAppointmentAsync(int id, AppointmentUpdateDto dto);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}
