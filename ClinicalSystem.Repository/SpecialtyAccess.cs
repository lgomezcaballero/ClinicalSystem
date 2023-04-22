using ClinicalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Repository
{
    public class SpecialtyAccess
    {
        public DataAccess data { get; set; }
        public SpecialtyAccess()
        {
            data = new DataAccess();
        }

        public List<Specialty> listing()
        {
            List<Specialty> list = new List<Specialty>();

            try
            {
                data.setSPQuery("SP_SpecialtyList");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Specialty aux = new Specialty();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["Especialidad"] is DBNull))
                        aux._Specialty = (string)data.Reader["Especialidad"];
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

        public Specialty GetSpecialty(int ID)
        {
            Specialty aux = new Specialty();

            try
            {
                data.setSPQuery("SP_GetSpecialty");
                data.setParameters("@ID", ID);
                data.executeRead();
                if (data.Reader.Read())
                {
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["Especialidad"] is DBNull))
                        aux._Specialty = (string)data.Reader["Especialidad"];
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
