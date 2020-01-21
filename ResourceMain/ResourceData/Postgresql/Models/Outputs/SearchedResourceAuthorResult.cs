using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs
{
    public class SearchedResourceAuthorResult
    {
        public List<Author> AuthorSearchResults { get; set; }
        public List<DetailedResource> ResourceSearchResults { get; set; }
    }
}
