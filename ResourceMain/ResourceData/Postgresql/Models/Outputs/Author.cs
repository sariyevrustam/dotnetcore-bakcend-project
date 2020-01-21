using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class Author
    {
        [JsonProperty(PropertyName = "author_id")]
        public int AuthorId { get; set; }

        [JsonProperty(PropertyName = "author_name")]
        public string AuthorName { get; set; }
    }
}
