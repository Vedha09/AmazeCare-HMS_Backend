using System;

namespace AmazeCareHMS.DTOs.Consultations
{
    public class ConsultationDto
    {
        public int ConsultationId { get; set; }
        public int AppointmentId { get; set; }

        public string Symptoms { get; set; }
        public string PhysicalExaminationNotes { get; set; }
        public string TreatmentPlan { get; set; }
        public string RecommendedTests { get; set; }
        
        // public AppointmentDto Appointment { get; set; }
    }
}
