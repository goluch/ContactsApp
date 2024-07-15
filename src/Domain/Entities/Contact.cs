using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Contact : BaseEntity<int>
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        //public Address Address { get; set; }
        public string Password { get; set; }
        public Category Category { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
