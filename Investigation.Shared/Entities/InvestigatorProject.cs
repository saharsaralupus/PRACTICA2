using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Investigation.Shared.Entities
{
    public class InvestigatorProject
    {
        public int Id{ get; set; }
        [JsonIgnore]
        public Project Projects { get; set; }
        public int ProjectId { get; set; }
        [JsonIgnore]
        public Investigator Investigators { get; set; }
        public int InvestigatorId { get; set; }

    }
}
