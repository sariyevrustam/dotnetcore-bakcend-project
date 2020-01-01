using MediatR;
using ResourceData.MessageBus.Commands;
using ResourceData.MessageBus.Events;
using ResourceDomainCore.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace ResourceData.MessageBus.CommandHandlers
{
    public class TestCommandHandler : IRequestHandler<TestCommand, bool>
    {
        private readonly IEventBus _bus;

        public TestCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new TestCreatedEvent(request.Token, request.TimeStamp));


            return Task.FromResult(true);
        }
    }
}
