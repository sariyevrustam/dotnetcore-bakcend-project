using Newtonsoft.Json;
using System;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class Resource
    {
        [JsonProperty(PropertyName = "resource_id")]
        public int? ResourceId { get; set; }
        
        [JsonProperty(PropertyName = "category_id")]
        public int? CategoryId { get; set; }
        
        [JsonProperty(PropertyName = "resource_name")]
        public string ResourceName { get; set; }
        
        [JsonProperty(PropertyName = "shelf")]
        public string Shelf { get; set; }

        [JsonProperty(PropertyName = "catalogue")]
        public string Catalogue { get; set; }

        [JsonProperty(PropertyName = "publish_year")]
        public int PublishYear { get; set; }

        [JsonProperty(PropertyName = "card_number")]
        public string CardNumber { get; set; }

        [JsonProperty(PropertyName = "rfid")]
        public string Rfid { get; set; }

        [JsonProperty(PropertyName = "updated_by")]
        public int? UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "deleted_by")]
        public int? DeletedBy { get; set; }

        [JsonProperty(PropertyName = "updated_on")]
        public DateTime? UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "deleted_on")]
        public DateTime? DeletedOn { get; set; }

        [JsonProperty(PropertyName = "is_deleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int? Rating { get; set; }

        [JsonProperty(PropertyName = "resource_type_id")]
        public int? ResourceTypeId { get; set; }

        [JsonProperty(PropertyName = "author_id")]
        public int? AuthorId { get; set; }

        [JsonProperty(PropertyName = "book_location_id")]
        public int? BookLocationId { get; set; }

        [JsonProperty(PropertyName = "catalog_id")]
        public int? CatalogId { get; set; }

        [JsonProperty(PropertyName = "current_status_id")]
        public int CurrentStatusId { get; set; }

        [JsonProperty(PropertyName = "current_status_name")]
        public string CurrentStatusName { get; set; }
    }
}
