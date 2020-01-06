using Newtonsoft.Json;
using ResourceData.MessageBus.Commands;
using ResourceData.MessageBus.Events;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs.BasketByUser;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Postgresql.PostgresqlRepository.Solid;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceData.MessageBus.EventHandlers
{
    public class BasketSubmittedByUserEventHandler : IEventHandler<BasketSubmittedByUserEvent>
    {
        private readonly IResourceRepository pgResourceRepository;
        private readonly IEventBus bus;

        public BasketSubmittedByUserEventHandler(IResourceRepository _pgResourceRepository,
            IEventBus _bus)
        {
            pgResourceRepository = _pgResourceRepository;
            bus = _bus;
        }

        public Task Handle(BasketSubmittedByUserEvent @event)
        {
            Console.WriteLine("BasketSubmittedByUserEventHandler --> ");

            ItemResult itemResult = pgResourceRepository.CheckAvailabilityForBasket(@event.SubmittedBasket);
            InCheckedBasketByUser inCheckedBasketByUser = (InCheckedBasketByUser) itemResult.Item;
            CheckBasketByUserCommand checkBasketByUserCommand = new CheckBasketByUserCommand(inCheckedBasketByUser, @event.UserId);
            bus.SendCommand(checkBasketByUserCommand);

            Console.WriteLine("BasketSubmittedByUserEventHandler --> CheckBasketByUserCommand sended");
            return Task.CompletedTask;
        }
    }
}
