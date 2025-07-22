using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Doctors
{
    public class DoctorRegisterDto
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

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
    }
}
