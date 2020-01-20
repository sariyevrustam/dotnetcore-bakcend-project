using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class PublishingHouse
    {
        [JsonProperty(PropertyName = "text_value")]
        public string TextValue { get; set; }
    }
}
