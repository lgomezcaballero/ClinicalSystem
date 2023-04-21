using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Entities
{
    public class MedicalConsultation
    {
        public long ID { get; set; }
        public Patient _Patient { get; set; }
        public QueryType _QueryType { get; set; }
        public Doctor _Doctor { get; set; }
        public DateTime DateRealization { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public decimal DisposableMaterialCost { get; set; }
    }
}
