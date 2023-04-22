using ClinicalSystem.Models;

namespace ClinicalSystem.Services
{
    public interface ISpecialtyServices
    {
        public List<SpecialtyViewModel> listing();
        public SpecialtyViewModel getSpecialty(int ID);
    }
}
