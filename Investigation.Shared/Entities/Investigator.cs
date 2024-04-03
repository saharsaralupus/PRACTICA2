using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class Investigator
    {
        public int Id { get; set; }

        public int Cedula { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 dcaracteres")]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]
        public string Nombre { get; set; }

        [Display(Name = "Afiliación")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 dcaracteres")]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]

        public string Afiliacion { get; set; }

        [Display(Name = "Especialidad")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100 dcaracteres")]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]
        public string Especialidad { get; set; }

    }
}
