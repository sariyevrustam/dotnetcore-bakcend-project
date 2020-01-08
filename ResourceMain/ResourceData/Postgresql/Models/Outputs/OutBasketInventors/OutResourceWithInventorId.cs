using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Outputs.OutBasketInventors
{
    public class OutResourceWithInventorId
    {
        public int InventorNumber { get; set; }
        public bool DoesExists { get; set; }
    }
}
