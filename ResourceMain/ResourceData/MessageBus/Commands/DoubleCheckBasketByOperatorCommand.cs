using ResourceData.Postgresql.Models.Inputs.AcceptedBasket;
using ResourceDomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Commands
{
    public class DoubleCheckBasketByOperatorCommand : Command
    {
        public InAcceptedBasket InAcceptedBasket { get; set; }

        public DoubleCheckBasketByOperatorCommand(InAcceptedBasket inAcceptedBasket)
        {
            InAcceptedBasket = inAcceptedBasket;
        }
    }
}
