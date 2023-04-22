using ClinicalSystem.Models;

namespace ClinicalSystem.Services
{
    public interface IMedicalConsultationServices
    {
        public bool Create(MedicalConsultationViewModel medicalConsultation);
        public bool Update(MedicalConsultationViewModel medicalConsultation);
        public bool Delete(int ID);
        public List<MedicalConsultationViewModel> listing();
        public MedicalConsultationViewModel getMedicalConsultation(int ID);
    }
}
