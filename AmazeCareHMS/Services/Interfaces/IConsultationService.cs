using AmazeCareHMS.DTOs.Consultations;

namespace AmazeCareHMS.Services.Interfaces
{
    public interface IConsultationService
    {
        Task<IEnumerable<ConsultationDto>> GetAllConsultationsAsync();
        Task<ConsultationDto> GetConsultationByIdAsync(int id);
        Task<ConsultationDto> CreateConsultationAsync(ConsultationCreateDto dto);
    }
}
