using ResourceData.Postgresql.Models.Outputs;
using ResourceDomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Commands
{
    public class AnnounceAvailableResourcesCommand : Command
    {
        public AvailableResourceCopyIds AvailableResourceCopyIds { get; set; }

        public AnnounceAvailableResourcesCommand(AvailableResourceCopyIds _availableResourceCopyIds)
        {
            AvailableResourceCopyIds = _availableResourceCopyIds;
        }
    }
}
