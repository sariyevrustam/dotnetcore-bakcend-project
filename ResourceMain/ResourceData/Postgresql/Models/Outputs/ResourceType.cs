using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class ResourceType
    {
        [JsonProperty(PropertyName = "resource_type_id")]
        public int ResourceTypeId { get; set; }

        [JsonProperty(PropertyName = "resource_type_name")]
        public string ResourceTypeName { get; set; }
    }
}
