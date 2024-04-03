using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class InvestigatorProyect
    {
        public int Id{ get; set; }

        //Se crea la foreign key de Proyect
        public int ProyectId { get; set; }
        public Proyect Proyects { get; set; }

        //Se crea la foreign key de Investigator
        public int InvestigatorId { get; set; }
        public Investigator Investigators { get; set; }



    }
}
