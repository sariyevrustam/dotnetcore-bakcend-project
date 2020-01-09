using ResourceData.MessageBus.Commands;
using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Events
{
    public class BasketDoubleChekcedEvent : Event
    {
        public DoubleCheckBasketByOperatorCommand doubleCheckBasketByOperatorCommand { get; set; }
        public BasketDoubleChekcedEvent(DoubleCheckBasketByOperatorCommand _doubleCheckBasketByOperatorCommand)
        {
            doubleCheckBasketByOperatorCommand = _doubleCheckBasketByOperatorCommand;
        }
    }
}
