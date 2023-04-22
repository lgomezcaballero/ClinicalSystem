using ClinicalSystem.Entities;
using ClinicalSystem.Models;
using ClinicalSystem.Repository;
using System.Net;

namespace ClinicalSystem.Services
{
    public class DoctorServices : IDoctorServices
    {
        public DoctorAccess data { get; set; }
        public DoctorServices()
        {
            data = new DoctorAccess();
        }
        public bool Create(DoctorViewModel doctor)
        {
            try
            {
                Doctor aux = new()
                {
                    ID = doctor.ID,
                    DNI = doctor.DNI,
                    Name = doctor.Name,
                    Active = doctor.Active
                };
                data.Add(aux);
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                data.Delete(ID);
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public DoctorViewModel getDoctor(int ID)
        {
            try
            {
                var aux = data.GetDoctor(ID);
                DoctorViewModel doctor = new()
                {
                    ID = aux.ID,
                    DNI = aux.DNI,
                    Name = aux.Name,
                    Active = aux.Active
                };
                return doctor;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<DoctorViewModel> listing()
        {
            try
            {
                List<DoctorViewModel> doctors = new List<DoctorViewModel>();
                DoctorAccess data = new DoctorAccess();
                foreach (var item in data.listing())
                {
                    if (item.Active)
                    {
                        DoctorViewModel aux = new()
                        {
                            ID = item.ID,
                            DNI = item.DNI,
                            Name = item.Name,
                            Active = item.Active
                        };
                        doctors.Add(aux);
                    }
                }
                return doctors;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool Update(DoctorViewModel doctor)
        {
            try
            {
                Doctor aux = new()
                {
                    ID = doctor.ID,
                    DNI = doctor.DNI,
                    Name = doctor.Name,
                    Active = doctor.Active
                };
                data.Update(aux);
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
