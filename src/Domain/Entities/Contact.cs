using Domain.Enums;

namespace Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
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
