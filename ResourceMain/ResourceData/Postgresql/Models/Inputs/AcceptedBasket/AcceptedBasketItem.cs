using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs.AcceptedBasket
{
    public class AcceptedBasketItem
    {        
        public int ResourceId { get; set; }
        public DateTime PermittedUntil { get; set; }
        public bool IsAvailable { get; set; }
    }
}
