using ClinicalSystem.Models;
using ClinicalSystem.Repository;

namespace ClinicalSystem.Services
{
    public class SpecialtyServices : ISpecialtyServices
    {
        public SpecialtyAccess data { get; set; }
        public SpecialtyServices()
        {
            data = new SpecialtyAccess();
        }
        public List<SpecialtyViewModel> listing()
        {
            try
            {
                List<SpecialtyViewModel> specialties = new List<SpecialtyViewModel>();
                foreach (var item in data.listing())
                {
                    SpecialtyViewModel aux = new()
                    {
                        ID = item.ID,
                        Specialty = item._Specialty
                    };
                    specialties.Add(aux);
                }
                return specialties;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public SpecialtyViewModel getSpecialty(int ID)
        {
            try
            {
                var aux = data.GetSpecialty(ID);
                SpecialtyViewModel doctor = new()
                {
                    ID = aux.ID,
                    Specialty = aux._Specialty
                };
                return doctor;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
