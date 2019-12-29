using System.Collections.Generic;

namespace ResourceData.Postgresql.Models.Inputs
{
    public class InBasket
    {
        public List<InDetailedResource> BasketResources { get; set; }
    }
}
