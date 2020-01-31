using MediatR;
using ResourceData.MessageBus.Commands;
using ResourceData.MessageBus.Events;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceData.MessageBus.CommandHandlers
{
    public class AnnounceAvailableResourcesCommandHandler : IRequestHandler<AnnounceAvailableResourcesCommand, bool>
    {
        private readonly IEventBus bus;

        public AnnounceAvailableResourcesCommandHandler(IEventBus _bus)
        {
            bus = _bus;
        }

        public Task<bool> Handle(AnnounceAvailableResourcesCommand request, CancellationToken cancellationToken)
        {
            bus.Publish(new AvailableResourcesAnnouncedEvent(request));

            return Task.FromResult(true);
        }
    }
}