using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs.BasketByUser
{
    public class InBasketResource
    {
        public int ResourceId { get; set; }
        public int TotalAvailableCount { get; set; }
        public string UsageLocationStatus { get; set; }
    }
}
