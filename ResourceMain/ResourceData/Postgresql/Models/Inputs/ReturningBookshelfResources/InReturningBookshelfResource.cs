using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs.ReturningBookshelfResources
{
    public class InReturningBookshelfResource
    {
        public int? ResourceId { get; set; }
        public string PhysicalState { get; set; }
    }
}
