namespace AmazeCareHMS.DTOs.Doctors
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string Specialty { get; set; }

        public int Experience { get; set; }

        public string Qualification { get; set; }

        public string Designation { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }  // Optional: if you want to include username
    }
}
