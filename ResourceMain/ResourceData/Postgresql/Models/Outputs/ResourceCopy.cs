using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class ResourceCopy
    {
        [JsonProperty(PropertyName = "resource_id")]
        public int? ResourceId { get; set; }
    }
}
