using ResourceData.MessageBus.Events;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceData.MessageBus.EventHandlers
{
    public class BasketSubmittedByUserEventHandler : IEventHandler<BasketSubmittedByUserEvent>
    {
        public Task Handle(BasketSubmittedByUserEvent @event)
        {
            Console.WriteLine("BasketSubmittedByUserEventHandler:  " + @event + "handled...");

            return Task.CompletedTask;
        }
    }
}
