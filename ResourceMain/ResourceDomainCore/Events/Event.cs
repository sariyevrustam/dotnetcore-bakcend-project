using System;

namespace ResourceDomainCore.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }
        public Guid GlobalID { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
            GlobalID = Guid.NewGuid();
        }
    }
}
