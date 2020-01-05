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
    public class CheckBasketByUserCommandHandler : IRequestHandler<CheckBasketByUserCommand, bool>
    {
        private readonly IEventBus bus;

        public CheckBasketByUserCommandHandler(IEventBus _bus)
        {            
            bus = _bus;
        }

        public Task<bool> Handle(CheckBasketByUserCommand request, CancellationToken cancellationToken)
        {            
            bus.Publish(new BasketByUserCheckedEvent(request));

            return Task.FromResult(true);
        }
    }
}
