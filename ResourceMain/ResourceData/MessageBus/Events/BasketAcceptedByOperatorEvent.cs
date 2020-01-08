using ResourceData.Postgresql.Models.Inputs.AcceptedBasket;
using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Events
{
    public class BasketAcceptedByOperatorEvent : Event
    {
        public InAcceptedBasket InAcceptedBasket  { get; set;}        
    }
}
