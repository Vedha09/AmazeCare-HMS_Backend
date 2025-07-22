using System;
using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Patients
{
    public class PatientRegisterDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        // Patient Info
        [Required, MaxLength(50)]
        public string PatientName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; }

        [Required, MaxLength(15)]
        [Phone]
        public string ContactNumber { get; set; }

        [MaxLength(200)]
        public string MedicalHistory { get; set; }
    }
}
