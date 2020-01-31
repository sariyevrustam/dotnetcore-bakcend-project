using ResourceData.MessageBus.Commands;
using ResourceData.Postgresql.Models.Outputs;
using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Events
{
    public class AvailableResourcesAnnouncedEvent : Event
    {
        public AvailableResourceCopyIds AvailableResourceCopyIds { get; set; }

        public AvailableResourcesAnnouncedEvent(AnnounceAvailableResourcesCommand _announceAvailableResourcesCommand)
        {
            AvailableResourceCopyIds = _announceAvailableResourcesCommand.AvailableResourceCopyIds;            
        }
    }
}
