using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class CurrentStatus
    {
        [JsonProperty(PropertyName = "current_status_id")]
        public string CurrentStatusId { get; set; }

        [JsonProperty(PropertyName = "current_status_name")]
        public string CurrentStatusName { get; set; }
    }
}
