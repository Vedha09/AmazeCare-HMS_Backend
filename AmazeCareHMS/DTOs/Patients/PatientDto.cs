using System;

namespace AmazeCareHMS.DTOs.Patients
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string ContactNumber { get; set; }

        public string MedicalHistory { get; set; }

        public string Username { get; set; }
    }
}
