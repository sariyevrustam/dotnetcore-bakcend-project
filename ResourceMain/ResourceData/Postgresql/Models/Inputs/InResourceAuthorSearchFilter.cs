using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs
{
    public class InResourceAuthorSearchFilter
    {
        public string SearchedText { get; set; }
        public int? LanguageId { get; set; }
        public int?[] CategoryIds { get; set; }
        public string PublishingHouseName { get; set; }
        public int? FromPublishYear { get; set; }
        public int? ToPublishYear { get; set; }
        public int? UsageLocationStatusId { get; set; }
    }
}
