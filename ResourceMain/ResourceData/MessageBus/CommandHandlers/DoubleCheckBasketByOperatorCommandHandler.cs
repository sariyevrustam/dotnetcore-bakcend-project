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
    public class DoubleCheckBasketByOperatorCommandHandler : IRequestHandler<DoubleCheckBasketByOperatorCommand, bool>
    {
        private readonly IEventBus bus;

        public DoubleCheckBasketByOperatorCommandHandler(IEventBus _bus)
        {
            bus = _bus;
        }

        public Task<bool> Handle(DoubleCheckBasketByOperatorCommand request, CancellationToken cancellationToken)
        {
            bus.Publish(new BasketDoubleChekcedEvent(request));
            return Task.FromResult(true);
        }
    }
}
