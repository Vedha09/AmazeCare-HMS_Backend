using AmazeCareHMS.DTOs.Prescriptions;
using AmazeCareHMS.Models;

namespace AmazeCareHMS.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDto>> GetAllPrescriptionsAsync();
        Task<IEnumerable<PrescriptionDto>> GetPrescriptionsByConsultationIdAsync(int consultationId);
        Task<PrescriptionDto> CreatePrescriptionAsync(PrescriptionCreateDto dto);
        Task<PrescriptionDto> UpdatePrescriptionAsync(int id, PrescriptionUpdateDto updatedPrescription);
    }
}
