using ResourceData.Postgresql.Models.Inputs.ReturningBookshelfResources;
using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Events
{
    public class ResourceCollectionReturnedForResourceEvent : Event
    {
        public InReturningBookshelfResourceCollection InReturningBookshelfResourceCollection { get; set; }
    }
}
