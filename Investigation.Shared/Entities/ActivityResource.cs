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

        public Resource Resources { get; set; }

        public Activity Activities { get; set; }
    }
}
