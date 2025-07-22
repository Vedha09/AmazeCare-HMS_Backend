using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AmazeCareHMS.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required, MaxLength(50)]
        public string DoctorName { get; set; }

        [Required, MaxLength(50)]
        public string Specialty { get; set; }

        [Required, Range(0, 60)]
        public int Experience { get; set; } 

        [Required, MaxLength(100)]
        public string Qualification { get; set; }

        [MaxLength(100)]
        public string Designation { get; set; }

        // Foreign key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation
        public ICollection<Appointment> Appointments { get; set; }
    }
}
