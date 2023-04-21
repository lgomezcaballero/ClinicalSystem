namespace ClinicalSystem.Models
{
    public class MedicalConsultationViewModel
    {
        public long ID { get; set; }
        public PatientViewModel Patient { get; set; }
        public QueryTypeViewModel QueryType { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public DateTime DateRealization { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public decimal DisposableMaterialCost { get; set; }
        public bool Active { get; set; }
    }
}
