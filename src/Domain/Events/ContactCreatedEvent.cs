using Domain.Common;

namespace Domain.Events
{
    public class ContactCreatedEvent : BaseEvent
    {
        public ContactCreatedEvent(Contact item)
        {
            Contact = item;
        }

        public Contact Contact { get; }
    }
}
