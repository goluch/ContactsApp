﻿using Domain.Common;

namespace Domain.Events
{
    public class ContactDeletedEvent : BaseEvent
    {
        public ContactDeletedEvent(Contact item)
        {
            Item = item;
        }

        public Contact Item { get; }
    }
}
