using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class UsageLocationStatus
    {
        [JsonProperty(PropertyName = "usage_location_status_id")]
        public string UsageLocationStatusId { get; set; }

        [JsonProperty(PropertyName = "usage_location_status_name")]
        public string UsageLocationStatusName { get; set; }
    }
}
