using System;
using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationId { get; set; }

        [Required]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [Required]
        [MaxLength(300)]
        public string Symptoms { get; set; }

        [MaxLength(300)]
        public string PhysicalExaminationNotes { get; set; }

        [MaxLength(300)]
        public string TreatmentPlan { get; set; }

        [MaxLength(300)]
        public string RecommendedTests { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
