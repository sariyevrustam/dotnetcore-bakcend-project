using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class ElectronResourceType
    {
        [JsonProperty(PropertyName = "electron_resource_type_id")]
        public int ElectronResourceTypeId { get; set; }

        [JsonProperty(PropertyName = "electron_resource_type_name")]
        public string ElectronResourceTypeName { get; set; }
    }
}
