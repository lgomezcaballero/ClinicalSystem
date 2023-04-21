using ClinicalSystem.Models;

namespace ClinicalSystem.Services
{
    public interface IPatientServices
    {
        public bool Create(PatientViewModel patient);
        public bool Update(PatientViewModel patient);
        public bool Delete(int id);
        public List<PatientViewModel> listing();
    }
}
