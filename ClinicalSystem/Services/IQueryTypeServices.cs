using ClinicalSystem.Models;

namespace ClinicalSystem.Services
{
    public interface IQueryTypeServices
    {
        public List<QueryTypeViewModel> listing();
        public QueryTypeViewModel getQueryType(int ID);
    }
}
