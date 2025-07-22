using System.ComponentModel.DataAnnotations;

namespace AmazeCareHMS.DTOs.Doctors
{
    public class DoctorUpdateDto
    {
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
