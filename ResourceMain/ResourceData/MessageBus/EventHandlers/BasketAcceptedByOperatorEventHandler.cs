using Newtonsoft.Json;
using ResourceData.MessageBus.Commands;
using ResourceData.MessageBus.Events;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs.AcceptedBasket;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResourceData.MessageBus.EventHandlers
{
    public class BasketAcceptedByOperatorEventHandler : IEventHandler<BasketAcceptedByOperatorEvent>
    {
        private readonly IResourceRepository pgResourceRepository;
        private readonly IEventBus bus;

        public BasketAcceptedByOperatorEventHandler(IResourceRepository _pgResourceRepository,
            IEventBus _bus)
        {
            pgResourceRepository = _pgResourceRepository;
            bus = _bus;
        }

        public Task Handle(BasketAcceptedByOperatorEvent @event)
        {
            Console.WriteLine("BasketAcceptedByOperatorEvent --> " + JsonConvert.SerializeObject(@event));
            ItemResult itemResult = pgResourceRepository.DoubleCheckBasketResources(@event.InAcceptedBasket);
            InAcceptedBasket inAcceptedBasket = (InAcceptedBasket) itemResult.Item;
            inAcceptedBasket.OperatorId = @event.InAcceptedBasket.OperatorId;
            Console.WriteLine("inacceptedbasket --> " + JsonConvert.SerializeObject(inAcceptedBasket));

            DoubleCheckBasketByOperatorCommand doubleCheckBasketByOperatorCommand = new DoubleCheckBasketByOperatorCommand(inAcceptedBasket);
            bus.SendCommand(doubleCheckBasketByOperatorCommand);
            
            //Console.WriteLine(JsonConvert.SerializeObject(@event));
           // Console.WriteLine("double checked basket -->" + JsonConvert.SerializeObject(inAcceptedBasket));           
                        
            return Task.CompletedTask;
        }
    }
}
