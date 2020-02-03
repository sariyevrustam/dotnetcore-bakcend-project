using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class DetailedResource
    {
        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        [JsonProperty(PropertyName = "author_name")]
        public string AuthorName { get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public int? CategoryId { get; set; }

        [JsonProperty(PropertyName = "resource_id")]
        public int? ResourceId { get; set; }

        [JsonProperty(PropertyName = "is_available")]
        public bool IsAvailable { get; set; }

        [JsonProperty(PropertyName = "publish_year")]
        public int PublishYear { get; set; }

        [JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; set; }

        [JsonProperty(PropertyName = "language_name")]
        public string LanguageName { get; set; }

        [JsonProperty(PropertyName = "resource_name")]
        public string ResourceName { get; set; }

        [JsonProperty(PropertyName = "resource_type_id")]
        public int? ResourceTypeId { get; set; }

        [JsonProperty(PropertyName = "resource_type_name")]
        public string ResourceTypeName { get; set; }

        /*[JsonProperty(PropertyName = "usage_location_status_id")]
        public string UsageLocationStatusId { get; set; }

        [JsonProperty(PropertyName = "usage_location_status_name")]
        public string UsageLocationStatusName { get; set; }*/

        [JsonProperty(PropertyName = "current_status_id")]
        public int CurrentStatusId { get; set; }

        [JsonProperty(PropertyName = "current_status_name")]
        public string CurrentStatusName { get; set; }
    }
}
