using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Prescriptions
{
    public class PrescriptionUpdateDto
    {
        public int PrescriptionId { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [Required]
        public string Dosage { get; set; }
        
        [Required, MaxLength(15)]
        public string Timing { get; set; }
    }
}
