using Newtonsoft.Json;
using ResourceData.MessageBus.Events;
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
            Console.WriteLine("ResourceCollectionReturnedForResourceEventHandler" + JsonConvert.SerializeObject(@event.InReturningBookshelfResourceCollection));
            return Task.CompletedTask;
        }
    }
}
