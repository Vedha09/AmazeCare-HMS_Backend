using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Consultations
{
    public class ConsultationCreateDto
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required, MaxLength(300)]
        public string Symptoms { get; set; }

        [MaxLength(300)]
        public string PhysicalExaminationNotes { get; set; }

        [MaxLength(300)]
        public string TreatmentPlan { get; set; }

        [MaxLength(300)]
        public string RecommendedTests { get; set; } // Optional: comma-separated
    }
}
