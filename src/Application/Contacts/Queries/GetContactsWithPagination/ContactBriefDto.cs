using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Contacts.Queries.GetContactsWithPagination
{
    public class ContactBriefDto
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Category Category { get; set; }
        public string Subcategory { get; set; }
        public int PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Contact, ContactBriefDto>();
            }
        }
    }
}
