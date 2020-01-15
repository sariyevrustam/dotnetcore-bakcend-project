using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs.ReturnedResource
{
    public class ReturnedResource
    {
        public int InventarNumber { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string AuthorName { get; set; }
    }
}
