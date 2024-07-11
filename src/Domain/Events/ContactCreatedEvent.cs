using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
