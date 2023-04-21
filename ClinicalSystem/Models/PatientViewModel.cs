namespace ClinicalSystem.Models
{
    public class PatientViewModel : PersonViewModel
    {
        public long ID { get; set; }
        public bool Active { get; set; }
    }
}
