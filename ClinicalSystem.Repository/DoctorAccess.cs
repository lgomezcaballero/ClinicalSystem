using ClinicalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Repository
{
    public class DoctorAccess
    {
        public List<Doctor> listing()
        {
            List<Doctor> list = new List<Doctor>();
            DataAccess data = new DataAccess();

            try
            {
                data.setSPQuery("SP_DoctorList");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Doctor aux = new Doctor();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["DNI"] is DBNull))
                        aux.DNI = (int)data.Reader["DNI"];

                    if (!(data.Reader["ID"] is DBNull))
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

        public bool Add(Doctor doctor)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setSPQuery("SP_AddDoctor");
                data.setParameters("@ID", doctor.ID);
                data.setParameters("@DNI", doctor.DNI);
                data.setParameters("@Nombre", doctor.Name);
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

        public bool Update(Doctor doctor)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setSPQuery("SP_ModifyDoctor");
                data.setParameters("@ID", doctor.ID);
                data.setParameters("@DNI", doctor.DNI);
                data.setParameters("@Nombre", doctor.Name);
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
            DataAccess data = new DataAccess();
            try
            {
                data.setSPQuery("SP_DeleteDoctor");
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

        public Doctor GetDoctor(int ID)
        {
            DataAccess data = new DataAccess();
            Doctor aux = new Doctor();

            try
            {
                data.setSPQuery("SP_GetDoctor");
                data.setParameters("@ID", ID);
                data.executeRead();
                if (data.Reader.Read())
                {
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["DNI"] is DBNull))
                        aux.DNI = (int)data.Reader["DNI"];

                    if (!(data.Reader["Nombre"] is DBNull))
                        aux.Name = (string)data.Reader["Nombre"];

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
    }
}
