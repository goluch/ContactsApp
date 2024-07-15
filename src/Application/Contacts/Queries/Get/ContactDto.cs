using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Contacts.Queries.Get
{
    public class ContactDto
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Category Category { get; set; }
        public int PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Contact, ContactDto>();
            }
        }
    }
}
