using System;
using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Appointments
{
    public class AppointmentUpdateDto
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required, MaxLength(150)]
        public string ReasonForVisit { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; }
    }
}
