using ResourceData.MessageBus.Commands;
using ResourceData.Postgresql.Models.Inputs.AcceptedBasket;
using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Events
{
    public class BasketDoubleChekcedEvent : Event
    {
        public InAcceptedBasket InAcceptedBasket { get; set; }
        public BasketDoubleChekcedEvent(DoubleCheckBasketByOperatorCommand _doubleCheckBasketByOperatorCommand)
        {
            InAcceptedBasket = _doubleCheckBasketByOperatorCommand.InAcceptedBasket;
        }
    }
}
