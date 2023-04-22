using ClinicalSystem.Entities;
using ClinicalSystem.Models;
using ClinicalSystem.Repository;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicalSystem.Services
{
    public class PatientServices : IPatientServices
    {
        public PatientAccess data { get; set; }
        public PatientServices()
        {
            data = new PatientAccess();
        }
        public bool Create(PatientViewModel patient)
        {
            try
            {
                Patient aux = new()
                {
                    DNI = patient.DNI,
                    Name = patient.Name,
                    Active = patient.Active
                };
                data.Add(aux);
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool Delete(int DNI)
        {
            try
            {
                data.Delete(DNI);
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<PatientViewModel> listing()
        {
            try
            {
                List<PatientViewModel> patients = new List<PatientViewModel>();
                PatientAccess data = new PatientAccess();
                foreach (var item in data.listing())
                {
                    if (item.Active)
                    {
                        PatientViewModel aux = new()
                        {
                            ID = item.ID,
                            DNI = item.DNI,
                            Name = item.Name,
                            Active = item.Active
                        };
                        patients.Add(aux);
                    }
                }
                return patients;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool Update(PatientViewModel patient)
        {
            try
            {
                Patient aux = new()
                {
                    ID = patient.ID,
                    DNI = patient.DNI,
                    Name = patient.Name,
                    Active = patient.Active
                };
                data.Update(aux);
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public PatientViewModel getPatient(int DNI)
        {
            try
            {
                var aux = data.GetPatient(DNI);
                PatientViewModel patient = new()
                {
                    ID = aux.ID,
                    DNI = aux.DNI,
                    Name = aux.Name,
                    Active = aux.Active
                };
                return patient;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
