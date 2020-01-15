using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.Models.Inputs.ReturningBookshelfResources
{
    public class InReturningBookshelfResourceCollection
    {
        public List<InReturningBookshelfResource> InReturningBookshelfResources { get; set; }
        public int AssignedUserId { get; set; }
        public int ReceiverOperatorId { get; set; }
    }
}
