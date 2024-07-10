﻿using ContactsApp.Domain.Common;

namespace ContactsApp.Domain.Entities
{
    public class Contact : BaseEntity<Guid>
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Category Category { get; set; }
        public string Subcategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
