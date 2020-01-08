using ResourceData.Postgresql.Models.Outputs.OutBasketInventors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs.OutBasketInventors
{
    public class OutBasketInventors
    {
        public List<OutResourceWithInventorId> CheckedResources { get; set; }
    }
}
