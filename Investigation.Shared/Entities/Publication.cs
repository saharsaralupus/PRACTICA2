﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class Publication
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Titulo { get; set; }

        [Display(Name = "Autor")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string  Autor { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateOnly FechaPublicacion { get; set; }

        [JsonIgnore]
        public Project Projects { get; set; }
        public int ProjectId { get; set; }


    }
}
