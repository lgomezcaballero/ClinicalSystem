using ClinicalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClinicalSystem.Repository
{
    public class PatientAccess
    {
        public List<Patient> listing()
        {
            List<Patient> list = new List<Patient>();
            DataAccess data = new DataAccess();

            try
            {
                data.setSPQuery("SP_PatientList");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Patient aux = new Patient();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID= (long)data.Reader["ID"];

                    if (!(data.Reader["DNI"] is DBNull))
                        aux.DNI = (int)data.Reader["DNI"];

                    if (!(data.Reader["Nombre"] is DBNull))
                        aux.Name = (string)data.Reader["Nombre"];

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

        public bool Add(Patient patient)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setSPQuery("SP_AddPatient");
                data.setParameters("@ID", patient.ID);
                data.setParameters("@DNI", patient.DNI);
                data.setParameters("@nombre", patient.Name);
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

        public bool Update(Patient patient)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setSPQuery("SP_ModifyPatient");
                data.setParameters("@DNI", patient.DNI);
                data.setParameters("@nombre", patient.Name);
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

        public bool Delete(int DNI)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setSPQuery("SP_DeletePatient");
                data.setParameters("@DNI", DNI);
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
    }
}
