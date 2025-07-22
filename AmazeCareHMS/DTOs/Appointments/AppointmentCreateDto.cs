using System;
using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Appointments
{
    public class AppointmentCreateDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [FutureDate(ErrorMessage = "Appointment date must be in the future.")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [MaxLength(150)]
        public string ReasonForVisit { get; set; }
    }

    // Custom Validation Attribute
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.Now;
            }
            return false;
        }
    }
}
