using ClinicalSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Repository
{
    public class QueryTypeAccess
    {
        public DataAccess data { get; set; }

        public QueryTypeAccess()
        {
            data = new DataAccess();
        }
        public List<QueryType> listing()
        {
            List<QueryType> list = new List<QueryType>();
            DataAccess data = new DataAccess();

            try
            {
                data.setSPQuery("SP_QueryTypeList");
                data.executeRead();
                while (data.Reader.Read())
                {
                    QueryType aux = new QueryType();
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["TipoConsulta"] is DBNull))
                        aux.Query = (string)data.Reader["TipoConsulta"];
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

        public QueryType GetQueryType(int ID)
        {
            DataAccess data = new DataAccess();
            QueryType aux = new QueryType();

            try
            {
                data.setSPQuery("SP_GetQueryType");
                data.setParameters("@ID", ID);
                data.executeRead();
                if (data.Reader.Read())
                {
                    if (!(data.Reader["ID"] is DBNull))
                        aux.ID = (int)data.Reader["ID"];

                    if (!(data.Reader["TipoConsulta"] is DBNull))
                        aux.Query = (string)data.Reader["TipoConsulta"];
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
