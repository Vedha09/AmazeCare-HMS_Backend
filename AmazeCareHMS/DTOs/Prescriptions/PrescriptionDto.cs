namespace AmazeCareHMS.DTOs.Prescriptions
{
    public class PrescriptionDto
    {
        public int PrescriptionId { get; set; }

        public int ConsultationId { get; set; }
        public int PatientId { get; set; }

        public string MedicineName { get; set; }

        public string Dosage { get; set; }

        public string Timing { get; set; }
    }
}
