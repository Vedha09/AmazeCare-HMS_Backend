using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AmazeCareHMS.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

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

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation
        public ICollection<Appointment> Appointments { get; set; }
    }
}
