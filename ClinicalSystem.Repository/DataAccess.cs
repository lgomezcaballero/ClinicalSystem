using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Repository
{
    public class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=ClinicalSystem; integrated security=true");
            command = new SqlCommand();
        }

        //public void setConsulta(string consulta)
        //{
        //    comando.CommandType = System.Data.CommandType.Text;
        //    //comando.CommandType = System.Data.CommandType.StoredProcedure;
        //    comando.CommandText = consulta;
        //}

        public void setSPQuery(string sp)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;
        }

        public void executeRead()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void runAction()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setParameters(string name, Object value)
        {
            command.Parameters.AddWithValue(name, value);
        }
        public void closeConnection()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }
    }
}
