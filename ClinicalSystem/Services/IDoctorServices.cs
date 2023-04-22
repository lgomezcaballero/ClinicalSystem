using ClinicalSystem.Models;

namespace ClinicalSystem.Services
{
    public interface IDoctorServices
    {
        public bool Create(DoctorViewModel doctor);
        public bool Update(DoctorViewModel doctor);
        public bool Delete(int ID);
        public List<DoctorViewModel> listing();
        public DoctorViewModel getDoctor(int ID);
    }
}
