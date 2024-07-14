using Domain.Common;

namespace Domain.Events
{
    public class ContactCompletedEvent : BaseEvent
    {
        public ContactCompletedEvent(Contact item)
        {
            Item = item;
        }

        public Contact Item { get; }
    }
}
