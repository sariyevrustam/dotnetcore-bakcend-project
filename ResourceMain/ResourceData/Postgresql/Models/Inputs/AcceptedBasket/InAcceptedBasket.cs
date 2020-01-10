using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs.AcceptedBasket
{
    public class InAcceptedBasket
    {
        public List<AcceptedBasketItem> AcceptedBasketItems { get; set; }
        public int AssigneeUserId { get; set; }
        public int OperatorId { get; set; }
    }
}
