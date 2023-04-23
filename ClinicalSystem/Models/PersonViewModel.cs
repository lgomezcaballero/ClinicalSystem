using System.ComponentModel.DataAnnotations;

namespace ClinicalSystem.Models
{
    public abstract class PersonViewModel
    {
        [Required(ErrorMessage = "Debe introducir un DNI")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "Debe introducir un nombre")]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
