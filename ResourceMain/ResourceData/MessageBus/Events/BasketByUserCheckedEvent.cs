using ResourceData.MessageBus.Commands;
using ResourceData.Postgresql.Models.Inputs.BasketByUser;
using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Events
{
    public class BasketByUserCheckedEvent : Event
    {
        public InCheckedBasketByUser CheckedBasketByUser { get; set; }
        public int UserId { get; set; }

        public BasketByUserCheckedEvent(CheckBasketByUserCommand _checkBasketByUserCommand)
        {
            CheckedBasketByUser = _checkBasketByUserCommand.CheckedBasketByUser;
            UserId = _checkBasketByUserCommand.UserId;
        }
    }
}


