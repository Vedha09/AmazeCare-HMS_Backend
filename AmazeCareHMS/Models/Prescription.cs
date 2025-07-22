using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazeCareHMS.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Required]
        public string MedicineName { get; set; }

        [Required]
        public string Dosage { get; set; }

        [Required]
        public string Timing { get; set; }

        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; }
    }
}
