using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Entities
{
    public class MedicalSpecialty
    {
        public DoctorViewModel Doctor { get; set; }
        public SpecialtyViewModel Specialty { get; set; }
    }
}
