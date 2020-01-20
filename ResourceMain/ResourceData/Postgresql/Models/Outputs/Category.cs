using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class Category
    {
        [JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }

        [JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; set; }

        [JsonProperty(PropertyName = "parent_category_id")]
        public int? ParentCategoryId { get; set; }

        [JsonProperty(PropertyName = "parent_category_name")]
        public string ParentCategoryName { get; set; }

        [JsonProperty(PropertyName = "category_language_id")]
        public int CategoryLanguageId { get; set; }

        [JsonProperty(PropertyName = "category_language")]
        public string CategoryLanguage { get; set; }
    }
}
