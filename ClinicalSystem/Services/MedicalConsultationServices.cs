using ClinicalSystem.Entities;
using ClinicalSystem.Models;
using ClinicalSystem.Repository;
using System.Collections.Generic;
using System.Net;

namespace ClinicalSystem.Services
{
    public class MedicalConsultationServices : IMedicalConsultationServices
    {
        public MedicalConsultationAccess data { get; set; }
        public MedicalConsultationServices()
        {
            data = new MedicalConsultationAccess();
        }
        public bool Create(MedicalConsultationViewModel medicalConsultation)
        {
            try
            {
                MedicalConsultation aux = new()
                {
                    ID = medicalConsultation.ID,
                    DateRealization = medicalConsultation.DateRealization,
                    Cost = medicalConsultation.Cost,
                    Description = medicalConsultation.Description,
                    DisposableMaterialCost = medicalConsultation.DisposableMaterialCost
                };
                aux._Patient.ID = medicalConsultation.Patient.ID;
                aux._QueryType.ID = medicalConsultation.QueryType.ID;
                aux._Specialty.ID = medicalConsultation._Specialty.ID;
                aux._Doctor.ID = medicalConsultation.Doctor.ID;

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

        public MedicalConsultationViewModel getMedicalConsultation(int ID)
        {
            try
            {
                var aux = data.GetMedicalConsultation(ID);
                MedicalConsultationViewModel medicalConsultation = new()
                {
                    ID = aux.ID,
                    DateRealization = aux.DateRealization,
                    Cost = aux.Cost,
                    Description = aux.Description,
                    DisposableMaterialCost = aux.DisposableMaterialCost,
                    Active = aux.Active
                };
                medicalConsultation.Patient = new()
                {
                    ID = aux._Patient.ID,
                    DNI = aux._Patient.DNI,
                    Name = aux._Patient.Name,
                    Active = aux._Patient.Active
                };
                medicalConsultation.Doctor = new()
                {
                    ID = aux._Doctor.ID,
                    DNI = aux._Doctor.DNI,
                    Name = aux._Doctor.Name,
                    Active = aux._Doctor.Active
                };
                medicalConsultation.QueryType = new()
                {
                    ID = aux._QueryType.ID,
                    Query = aux._QueryType.Query
                };
                medicalConsultation._Specialty = new()
                {
                    ID = aux._Specialty.ID,
                    Specialty = aux._Specialty._Specialty
                };
                medicalConsultation.Doctor = new()
                {
                    ID = aux._Doctor.ID,
                    DNI = aux._Doctor.DNI,
                    Name = aux._Doctor.Name,
                    Active = aux._Doctor.Active
                };
                return medicalConsultation;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<MedicalConsultationViewModel> listing()
        {
            try
            {
                List<MedicalConsultationViewModel> list = new List<MedicalConsultationViewModel>();
                foreach (var item in data.listing())
                {
                    if (item.Active)
                    {
                        MedicalConsultationViewModel aux = new()
                        {
                            ID = item.ID,
                            DateRealization = item.DateRealization,
                            Cost = item.Cost,
                            Description = item.Description,
                            DisposableMaterialCost = item.DisposableMaterialCost
                        };
                        aux.Patient.ID = item._Patient.ID;
                        aux.QueryType.ID = item._QueryType.ID;
                        aux._Specialty.ID = item._Specialty.ID;
                        aux.Doctor.ID = item._Doctor.ID;
                        list.Add(aux);
                    }
                }
                return list;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool Update(MedicalConsultationViewModel medicalConsultation)
        {
            try
            {
                MedicalConsultation aux = new()
                {
                    ID = medicalConsultation.ID,
                    DateRealization = medicalConsultation.DateRealization,
                    Cost = medicalConsultation.Cost,
                    Description = medicalConsultation.Description,
                    DisposableMaterialCost = medicalConsultation.DisposableMaterialCost
                };
                aux._Patient.ID = medicalConsultation.Patient.ID;
                aux._QueryType.ID = medicalConsultation.QueryType.ID;
                aux._Specialty.ID = medicalConsultation._Specialty.ID;
                aux._Doctor.ID = medicalConsultation.Doctor.ID;

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
