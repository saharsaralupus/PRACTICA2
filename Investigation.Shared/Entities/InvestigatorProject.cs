using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class InvestigatorProject
    {
        public int Id{ get; set; }

        public Project Projects { get; set; }

        public Investigator Investigators { get; set; }



    }
}
