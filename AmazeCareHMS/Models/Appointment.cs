using System;
using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [Required, MaxLength(150)]
        public string ReasonForVisit { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        // Navigation
        public Consultation Consultation { get; set; }  
    }
}
