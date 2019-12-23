using ResourceDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceDomain.Events
{
    public class TestCreatedEvent : Event
    {
        public string Token { get; set; }
        public DateTime TimeStamp { get; set; }

        public TestCreatedEvent(string token, DateTime timeStamp)
        {
            Token = token;
            Timestamp = timeStamp;
        }
    }
}
