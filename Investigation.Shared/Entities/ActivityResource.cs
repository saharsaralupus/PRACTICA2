using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class ActivityResource
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Resource Resources { get; set; }
        public int ResourceId { get; set; }
        [JsonIgnore]
        public Activity Activities { get; set; }
        public int ActivityId { get; set; }
    }
}
