using Newtonsoft.Json;
using ResourceData.MessageBus.Commands;
using ResourceData.MessageBus.Events;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Outputs;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceData.MessageBus.EventHandlers
{
    public class ResourceCollectionReturnedForResourceEventHandler : IEventHandler<ResourceCollectionReturnedForResourceEvent>
    {
        private readonly IResourceRepository pgResourceRepository;
        private readonly IEventBus eventBus;

        public ResourceCollectionReturnedForResourceEventHandler(IResourceRepository _pgResourceRepository,
            IEventBus _eventBus)
        {
            pgResourceRepository = _pgResourceRepository;
            eventBus = _eventBus;
        }

        public Task Handle(ResourceCollectionReturnedForResourceEvent @event)
        {
            pgResourceRepository.ReturnResources(@event.InReturningBookshelfResourceCollection);

            ItemResult itemResult = pgResourceRepository.GetAvailableCopyIds(@event.InReturningBookshelfResourceCollection);
            AnnounceAvailableResourcesCommand announceAvailableResourcesCommand = new AnnounceAvailableResourcesCommand(
                new AvailableResourceCopyIds()
                {
                    ResourceCopies = (List<ResourceCopy>)itemResult.Item
                }
                );
            eventBus.SendCommand(announceAvailableResourcesCommand);

            return Task.CompletedTask;
        }
    }
}
