using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Prescriptions
{
    public class PrescriptionCreateDto
    {
        [Required]
        public int ConsultationId { get; set; }

        [Required, MaxLength(100)]
        public string MedicineName { get; set; }

        [Required, MaxLength(50)]
        public string Dosage { get; set; }

        [Required, MaxLength(20)]
        public string Timing { get; set; }
    }
}
