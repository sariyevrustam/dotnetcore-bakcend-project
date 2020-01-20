using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class Language
    {
        [JsonProperty(PropertyName = "language_id")]
        public string LanguageId { get; set; }

        [JsonProperty(PropertyName = "language_name")]
        public string LanguageName { get; set; }
    }
}
