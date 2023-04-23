using System.ComponentModel.DataAnnotations;

namespace ClinicalSystem.Models
{
    public class MedicalConsultationViewModel
    {
        public long ID { get; set; }
        public PatientViewModel Patient { get; set; }
        public QueryTypeViewModel QueryType { get; set; }
        public SpecialtyViewModel _Specialty { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public DateTime DateRealization { get; set; }
        [Required(ErrorMessage ="Debe introducir el costo")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Debe introducir una descripción")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Debe introducir el costo de material descartable")]
        public decimal DisposableMaterialCost { get; set; }
        
        [Required]
        public bool Active { get; set; }
    }
}
