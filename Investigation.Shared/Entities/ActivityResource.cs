using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class ActivityResource
    {
        public int Id { get; set; }

        // Se crea la foreign key de Resource
        public int ResourceId { get; set; }
        public Resource Resources { get; set; }

        // Specify ON DELETE NO ACTION for the foreign key
        [ForeignKey("ResourceId")]
        public virtual Resource Resource { get; set; }

        // Se crea la foreign key de Activity
        public int ActivityId { get; set; }
        public Activity Activities { get; set; }

        // Specify ON DELETE NO ACTION for the foreign key
        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }



    }
}
