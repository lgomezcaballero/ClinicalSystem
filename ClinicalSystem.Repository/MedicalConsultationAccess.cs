using ClinicalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Repository
{
    public class MedicalConsultationAccess
    {
        public DataAccess data { get; set; }

        public MedicalConsultationAccess()
        {
            data = new DataAccess();
        }
        public List<MedicalConsultation> listing()
        {
            List<MedicalConsultation> list = new List<MedicalConsultation>();
            PatientAccess patient = new PatientAccess();
            
            try
            {
                data.setSPQuery("SP_MedicalConsultationList");
                data.executeRead();
                while (data.Reader.Read())
                {
                    MedicalConsultation aux = new MedicalConsultation();
                    QueryTypeAccess query = new QueryTypeAccess();
                    DoctorAccess doctor = new DoctorAccess();
                    SpecialtyAccess specialty = new SpecialtyAccess();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];
                    
                    if (!(data.Reader["DNI"] is DBNull))
                        aux._Patient = patient.GetPatient((int)data.Reader["DNI"]);
                    
                    if (!(data.Reader["IDTipoConsulta"] is DBNull))
                        aux._QueryType = query.GetQueryType((int)data.Reader["IDTipoConsulta"]);

                    if (!(data.Reader["IDEspecialidad"] is DBNull))
                        aux._Specialty = specialty.GetSpecialty((int)data.Reader["IDEspecialidad"]);

                    if (!(data.Reader["NroMatricula"] is DBNull))
                        aux._Doctor = doctor.GetDoctor((int)data.Reader["NroMatricula"]);

                    if (!(data.Reader["FechaRealizacion"] is DBNull))
                        aux.DateRealization = (DateTime)data.Reader["FechaRealizacion"];

                    if (!(data.Reader["Costo"] is DBNull))
                        aux.Cost = (decimal)data.Reader["Costo"];

                    if (!(data.Reader["Descripcion"] is DBNull))
                        aux.Description = (string)data.Reader["Descripcion"];

                    if (!(data.Reader["CostoMaterialDescartable"] is DBNull))
                        aux.DisposableMaterialCost = (decimal)data.Reader["CostoMaterialDescartable"];

                    if (!(data.Reader["Activo"] is DBNull))
                        aux.Active = (bool)data.Reader["Activo"];
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                data.closeConnection();
            }
        }

        public bool Add(MedicalConsultation medicalConsultation)
        {
            try
            {
                data.setSPQuery("SP_AddMedicalConsultation");
                data.setParameters("@NroHistoriaClinica", medicalConsultation._Patient.ID);
                data.setParameters("@IDTipoConsulta", medicalConsultation._QueryType.ID);
                data.setParameters("@IDEspecialidad", medicalConsultation._Specialty.ID);
                data.setParameters("@NroMatricula", medicalConsultation._Doctor.ID);
                data.setParameters("@FechaRealizacion", medicalConsultation.DateRealization);
                data.setParameters("@Costo", medicalConsultation.Cost);
                data.setParameters("@Descripcion", medicalConsultation.Description);
                data.setParameters("@CostoMaterialDescartable", medicalConsultation.DisposableMaterialCost);
                data.runAction();
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                data.closeConnection();
            }
        }

        public bool Update(MedicalConsultation medicalConsultation)
        {
            try
            {
                data.setSPQuery("SP_ModifyMedicalConsultation");
                data.setParameters("@IDConsulta", medicalConsultation.ID);
                data.setParameters("@FechaRealizacion", medicalConsultation.DateRealization);
                data.setParameters("@Descripcion", medicalConsultation.Description);
                data.runAction();

                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                data.closeConnection();
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                data.setSPQuery("SP_DeletemedicalConsultation");
                data.setParameters("@ID", ID);
                data.runAction();
                return true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                data.closeConnection();
            }
        }

        public MedicalConsultation GetMedicalConsultation(int ID)
        {

            try
            {
                data.setSPQuery("SP_GetMedicalConsultation");
                data.setParameters("@ID", ID);
                data.executeRead();
                
                MedicalConsultation aux = new MedicalConsultation();
                if (data.Reader.Read())
                {
                    PatientAccess patient = new PatientAccess();
                    QueryTypeAccess query = new QueryTypeAccess();
                    DoctorAccess doctor = new DoctorAccess();
                    SpecialtyAccess specialty = new SpecialtyAccess();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["DNI"] is DBNull))
                        aux._Patient = patient.GetPatient((int)data.Reader["DNI"]);

                    if (!(data.Reader["IDTipoConsulta"] is DBNull))
                        aux._QueryType = query.GetQueryType((int)data.Reader["IDTipoConsulta"]);

                    if (!(data.Reader["IDEspecialidad"] is DBNull))
                        aux._Specialty = specialty.GetSpecialty((int)data.Reader["IDEspecialidad"]);

                    if (!(data.Reader["NroMatricula"] is DBNull))
                        aux._Doctor = doctor.GetDoctor((int)data.Reader["NroMatricula"]);

                    if (!(data.Reader["FechaRealizacion"] is DBNull))
                        aux.DateRealization = (DateTime)data.Reader["FechaRealizacion"];

                    if (!(data.Reader["Costo"] is DBNull))
                        aux.Cost = (decimal)data.Reader["Costo"];

                    if (!(data.Reader["Descripcion"] is DBNull))
                        aux.Description = (string)data.Reader["Descripcion"];

                    if (!(data.Reader["CostoMaterialDescartable"] is DBNull))
                        aux.DisposableMaterialCost = (decimal)data.Reader["CostoMaterialDescartable"];

                    if (!(data.Reader["Activo"] is DBNull))
                        aux.Active = (bool)data.Reader["Activo"];
                }
                return aux;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                data.closeConnection();
            }
        }

        public List<MedicalConsultation> GetMedicalConsultationByPatient(int NroHistoriaClinica)
        {
            List<MedicalConsultation> list = new List<MedicalConsultation>();
            try
            {
                data.setSPQuery("SP_GetMedicalConsultationByPatient");
                data.setParameters("@NroHistoriaClinica", NroHistoriaClinica);
                data.executeRead();

                while (data.Reader.Read())
                {
                    MedicalConsultation aux = new MedicalConsultation();
                    PatientAccess patient = new PatientAccess();
                    QueryTypeAccess query = new QueryTypeAccess();
                    DoctorAccess doctor = new DoctorAccess();
                    SpecialtyAccess specialty = new SpecialtyAccess();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["DNI"] is DBNull))
                        aux._Patient = patient.GetPatient((int)data.Reader["DNI"]);

                    if (!(data.Reader["IDTipoConsulta"] is DBNull))
                        aux._QueryType = query.GetQueryType((int)data.Reader["IDTipoConsulta"]);

                    if (!(data.Reader["IDEspecialidad"] is DBNull))
                        aux._Specialty = specialty.GetSpecialty((int)data.Reader["IDEspecialidad"]);

                    if (!(data.Reader["NroMatricula"] is DBNull))
                        aux._Doctor = doctor.GetDoctor((int)data.Reader["NroMatricula"]);

                    if (!(data.Reader["FechaRealizacion"] is DBNull))
                        aux.DateRealization = (DateTime)data.Reader["FechaRealizacion"];

                    if (!(data.Reader["Costo"] is DBNull))
                        aux.Cost = (decimal)data.Reader["Costo"];

                    if (!(data.Reader["Descripcion"] is DBNull))
                        aux.Description = (string)data.Reader["Descripcion"];

                    if (!(data.Reader["CostoMaterialDescartable"] is DBNull))
                        aux.DisposableMaterialCost = (decimal)data.Reader["CostoMaterialDescartable"];

                    if (!(data.Reader["Activo"] is DBNull))
                        aux.Active = (bool)data.Reader["Activo"];

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}
