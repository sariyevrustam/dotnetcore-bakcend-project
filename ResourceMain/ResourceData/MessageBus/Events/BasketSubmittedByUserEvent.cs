﻿using ResourceData.Postgresql.Models.Inputs;
using ResourceDomainCore.Events;

namespace ResourceData.MessageBus.Events
{
    public class BasketSubmittedByUserEvent : Event
    {
        public InBasket SubmittedBasket { get; set; }
        public int UserId { get; set; }        
    }
}
