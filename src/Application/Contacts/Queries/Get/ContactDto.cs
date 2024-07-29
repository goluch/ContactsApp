using AutoMapper;
using Domain.Entities;

namespace Application.Contacts.Queries.Get
{
    public class ContactDto
    {
        public string Forename { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public CategoryDto Category { get; init; }
        public string PhoneNumber { get; init; }
        public DateOnly BirthDate { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Contact, ContactDto>();
            }
        }
    }
}
