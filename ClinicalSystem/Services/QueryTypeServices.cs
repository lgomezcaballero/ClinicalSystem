using ClinicalSystem.Models;
using ClinicalSystem.Repository;

namespace ClinicalSystem.Services
{
    public class QueryTypeServices : IQueryTypeServices
    {
        public QueryTypeAccess data { get; set; }
        public QueryTypeServices()
        {
            data = new QueryTypeAccess();
        }
        public QueryTypeViewModel getQueryType(int ID)
        {
            try
            {
                var aux = data.GetQueryType(ID);
                QueryTypeViewModel query = new()
                {
                    ID = aux.ID,
                    Query = aux.Query,
                };
                return query;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<QueryTypeViewModel> listing()
        {
            try
            {
                List<QueryTypeViewModel> queries = new List<QueryTypeViewModel>();
                QueryTypeAccess data = new QueryTypeAccess();
                foreach (var item in data.listing())
                {
                    QueryTypeViewModel aux = new()
                    {
                        ID = item.ID,
                        Query = item.Query
                    };
                    queries.Add(aux);
                }
                return queries;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
