using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class Activity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 dcaracteres")]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100 dcaracteres")]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]
        public DateTime FechaInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligaptorio")]
        public DateTime FechaFinal { get; set; }

        [JsonIgnore]
        public Project Projects { get; set; }


    }


}
